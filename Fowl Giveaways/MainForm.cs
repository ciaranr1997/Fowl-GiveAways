using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SQLite;

namespace Fowl_Giveaways
{
    public partial class MainForm : Form
    {
        //default values, changed by config 
        private String GiveAwayID = "-1";
        private String GiveAwayName;
        private Int64 wait = 100; 
        private Int64 loops = 2;
        /// <summary>
        /// Loads and shows the main form 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            StartUpChecks();
            try
            {
                Database db = new Database();
                db.Open();
                db.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e.ToString());
            }
        }
        /// <summary>
        /// Change all the giveaway details to the giveaway id provided
        /// </summary>
        /// <param name="value"></param>
        public void ChangeGiveaway(String id)
        {
            GiveAwayID = id;
            if (id == "-1")
            {
                GiveAwayMembers.ReadOnly = true;
                giveawayName.Text = "Please select/create a giveaway...";
            }
            else
            {
                Database db = new Database();
                db.Open();
                SQLiteDataReader res = db.Select("SELECT month FROM giveaways WHERE id=" + id);
                while (res.Read())
                {
                    GiveAwayName = res.GetValues()[0].ToString();
                }
                res.Close();
                db.Insert("UPDATE settings set setting_value=" + GiveAwayID + " where setting_name='last_giveaway'");
                db.Close();
                giveawayName.Text = GiveAwayName + " Giveaway";
                GiveAwayMembers.ReadOnly = false;
                LoadDetails();
            }
        }
        /// <summary>
        /// <para>Perform the startup checks when the program is opened</para>
        /// <para>This checks the database exists and sets it up if it doesn't. If it does exist it loads in all the relevant details.</para>
        /// </summary>
        private void StartUpChecks()
        {
            String path = Directory.GetCurrentDirectory();
            String name = "fowl.sqlite";
            if (!File.Exists(path + "/" + name))
            {
                try
                {
                    File.Create(path + "/" + name).Close();
                    Thread.Sleep(500);
                    string query = "CREATE TABLE \"giveaways\" ("
                                        + "\"id\"    INTEGER PRIMARY KEY AUTOINCREMENT,"
                                        + "\"month\" varchar(20) NOT NULL,"
                                        + "\"item_count\"    INTEGER,"
                                        + "\"allow_multi\"    INTEGER,"
                                        + "\"is_deleted\"    INTEGER"
                                        + "); "
                                        + "CREATE TABLE \"giveaway_items\"("
                                        + "\"id\"    INTEGER PRIMARY KEY AUTOINCREMENT,"
                                        + "\"giveaway\"  INTEGER,"
                                        + "\"item_name\" varchar(200),"
                                        + "\"quantity\"  INTEGER," 
                                        + "\"won\"  INTEGER DEFAULT 0"
                                        + ");"
                                        + "CREATE TABLE \"settings\" ("
                                        + "	\"id\"	INTEGER PRIMARY KEY AUTOINCREMENT,"
                                        + "	\"setting_name\"	varchar(200),"
                                        + "	\"setting_value\"	INTEGER,"
                                        + "	\"can_edit\"	INTEGER"
                                        + ");"
                                        + "INSERT into settings (setting_name,setting_value,can_edit) VALUES('last_giveaway',-1,0); "
                                        + "INSERT into settings (setting_name,setting_value,can_edit) VALUES('speed (ms)',100,1); "
                                        + "INSERT into settings (setting_name,setting_value,can_edit) VALUES('loops',2,1); ";

                    Database db = new Database();
                    db.Open();
                    db.Insert(query);
                    db.Close();
                    giveawayName.Text = "No Giveaways yet. Please create one";
                    GiveAwayMembers.ReadOnly = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    MessageBox.Show(e.ToString());
                }

            }
            else
            {
                //check the most recent giveaway
                string lasttable = "-1";
                Database db = new Database();
                db.Open();
                string mostrecent = "SELECT setting_value FROM settings where setting_name='last_giveaway' ORDER BY ID DESC LIMIT 1";
                SQLiteDataReader mrres = db.Select(mostrecent);
                if (mrres.HasRows)
                {
                    while (mrres.Read())
                    {
                        lasttable = mrres.GetValues()[0].ToString();
                    }
                    ChangeGiveaway(lasttable);
                }
                mrres.Close();
                if (lasttable == "-1")
                {
                    //load the most recent giveaway
                    string query = "SELECT * FROM giveaways WHERE is_deleted <> 1 ORDER BY ID DESC LIMIT 1";

                    SQLiteDataReader res = db.Select(query);
                    if (res.HasRows)
                    {
                        String id = "";
                        while (res.Read())
                        {
                            id = res.GetValues()[0].ToString();
                        }
                        ChangeGiveaway(id);
                    }
                    else
                    {
                        giveawayName.Text = "No Giveaways yet. Please create one";
                    }
                }
                db.Close();

            }
            LoadConfig();
        }
        /// <summary>
        /// <para>Loads the details of all the giveaway members who are not marked as having won an item</para>
        /// </summary>
        private void LoadDetails()
        {
            GiveAwayMembers.Rows.Clear();
            string getMembers = "SELECT id,username,name,entry_count FROM " + GiveAwayName + "_giveaway_members where winner IS NULL order by name asc";
            Database db = new Database();
            db.Open();
            SQLiteDataReader members = db.Select(getMembers);
            if (members.HasRows)
            {
                while (members.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)GiveAwayMembers.Rows[0].Clone();
                    row.Cells[0].Value = members.GetValues()[0].ToString();
                    row.Cells[1].Value = members.GetValues()[1].ToString();
                    row.Cells[2].Value = members.GetValues()[2].ToString();
                    row.Cells[3].Value = members.GetValues()[3].ToString();
                    GiveAwayMembers.Rows.Add(row);
                }
            }
            members.Close();
            db.Close();
        }
        /// <summary>
        /// Runs through the items and picks the winner for each one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pickWinner_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                if (GiveAwayID != "-1")
                {
                    //check how many items there are for this 
                    String selectItems = "SELECT id,item_name,quantity,won FROM giveaway_items where giveaway=" + GiveAwayID;
                    Database db = new Database();
                    db.Open();
                    SQLiteDataReader itemRes = db.Select(selectItems);
                    if (itemRes.HasRows)
                    {
                        List<Item> items = new List<Item>();
                        while (itemRes.Read())
                        {
                            String itemID = itemRes.GetValue(0).ToString();
                            String itemName = (String)itemRes.GetValue(1);
                            Int64 itemCount = (Int64)itemRes.GetValue(2);
                            Int64 itemsWon = (Int64)itemRes.GetValue(3);
                            items.Add(new Item(itemID,itemName,itemCount,itemsWon));
                        }
                        itemRes.Close();
                        db.Close();
                        foreach(Item item in items)
                        {
                            if (item.itemsWon < item.itemCount)
                            {
                                item.itemCount = item.itemCount - item.itemsWon;//so we don't double gift
                                if (item.itemCount == 1)
                                {
                                    GetWinner(item.itemID, item.itemName, 1, 1);
                                }
                                else
                                {
                                    for (int i = 0; i < item.itemCount; i++)
                                    {
                                        int itemNo = i + 1;
                                        GetWinner(item.itemID, item.itemName, itemNo, (int)item.itemCount);
                                    }
                                }
                            }
                        }
                        Winners win = new Winners(GiveAwayID);
                        win.ShowDialog();
                    }
                    else
                    {
                        itemRes.Close();
                        db.Close();
                        MessageBox.Show("There are currently no items for this giveaway. Please add some");

                        Giveaway ga = new Giveaway(this);
                        ga.Show();
                        ga.Setup(GiveAwayID);
                    }
                }
                else
                {
                    MessageBox.Show("You have not got a giveaway selected. Please either create one or select one");
                }
            }).Start();
            
        }
        /// <summary>
        /// Runs through the list of giveaway members and picks a winner. Accounts for multiple entries too.
        /// </summary>
        /// <param name="itemID"></param>
        private void GetWinner(String itemID, String itemName, int itemNumber, int itemCount)
        {
            if (GiveAwayMembers.RowCount > 1)
            {
                try
                {
                    List<Entry> entries = new List<Entry>();
                    foreach (DataGridViewRow row in GiveAwayMembers.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                            Int32.TryParse(row.Cells[3].Value.ToString(), out int entCount);
                            for (int i = 0; i < entCount; i++)
                            {
                                Entry tmpEnt = new Entry(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Index);
                                entries.Add(tmpEnt);
                            }
                        }
                    }
                    var random = new Random();
                    int index = random.Next(entries.Count);
                    int winrow = entries[index].Row;
                    //now do all the pretty stuff
                    int counter = 0;
                    for (int i = 0; i < GiveAwayMembers.RowCount - 1; i++)
                    {
                        if (GiveAwayMembers.Rows[i].Cells[0].Value != null)
                        {
                            if (i != 0)
                            {
                                GiveAwayMembers.Rows[i - 1].DefaultCellStyle.BackColor = Color.White;

                            }
                            else if (counter > 0)
                            {
                                GiveAwayMembers.Rows[GiveAwayMembers.RowCount - 2].DefaultCellStyle.BackColor = Color.White;
                            }
                            if (i < 7)
                            {
                                Invoke((MethodInvoker)delegate
                                {
                                    GiveAwayMembers.FirstDisplayedScrollingRowIndex = 0;
                                });
                            }
                            else
                            {
                                Invoke((MethodInvoker)delegate
                                {
                                    GiveAwayMembers.FirstDisplayedScrollingRowIndex = i - 6;
                                });
                            }
                            GiveAwayMembers.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            Thread.Sleep((int)wait);
                            if (counter == loops && i == winrow)
                            {
                                break;
                            }
                            else
                            {

                            }
                        }
                        if (i == GiveAwayMembers.RowCount - 2)
                        {
                            counter++;
                            i = -1;
                        }
                    }
                    //remove the person from the giveaway list so they don't get picked twice
                    Invoke((MethodInvoker)delegate
                    {
                        GiveAwayMembers.Rows.Remove(GiveAwayMembers.Rows[winrow]);
                    });
                    if (itemCount == 1)
                    {
                        MessageBox.Show("The Winner of " + itemName +  " is " + entries[index].Username + " :)!");
                    }
                    else
                    {
                        MessageBox.Show("The Winner of " + itemName + " ("+itemNumber+"/"+ itemCount + ") is " + entries[index].Username + " :)!");
                    }
                    string userId = (String)GiveAwayMembers.Rows[winrow].Cells[0].Value;
                    string updateQueries = "UPDATE " + GiveAwayName + "_giveaway_members set winner=" + itemID + " where id=" + userId+"; "
                                         + "UPDATE giveaway_items set won=won+1 where id="+itemID;
                    Database db = new Database();
                    db.Open();
                    db.Insert(updateQueries);
                    db.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("You should probably add some giveaway members");
            }
            
        }
        /// <summary>
        /// <para>Updates all the fields as they're changed for the relevant member.</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GiveAwayMembers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                if (GiveAwayMembers.RowCount > 1)
                {
                    if (GiveAwayMembers.Rows[e.RowIndex].Cells[3].Value == null)
                    {
                        GiveAwayMembers.Rows[e.RowIndex].Cells[3].Value = 1;
                    }
                    if (e.ColumnIndex == 1)
                    {
                        if (GiveAwayMembers.Rows[e.RowIndex].Cells[2].Value == null)
                        {
                            GiveAwayMembers.Rows[e.RowIndex].Cells[2].Value = GiveAwayMembers.Rows[e.RowIndex].Cells[1].Value;
                        }
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        if (GiveAwayMembers.Rows[e.RowIndex].Cells[1].Value == null)
                        {
                            GiveAwayMembers.Rows[e.RowIndex].Cells[1].Value = GiveAwayMembers.Rows[e.RowIndex].Cells[2].Value;
                        }
                    }
                    Database db = new Database();
                    db.Open();
                    if (GiveAwayMembers.Rows[e.RowIndex].Cells[0].Value == null)
                    {
                        if (GiveAwayMembers.Rows[e.RowIndex].Cells[1].Value != null && GiveAwayMembers.Rows[e.RowIndex].Cells[2].Value != null)
                        {
                            string insert = "INSERT INTO " + GiveAwayName + "_giveaway_members (username,name,entry_count) VALUES('" + GiveAwayMembers.Rows[e.RowIndex].Cells[1].Value.ToString() + "','" + GiveAwayMembers.Rows[e.RowIndex].Cells[2].Value.ToString() + "'," + GiveAwayMembers.Rows[e.RowIndex].Cells[3].Value.ToString() + ")";
                            db.Insert(insert);
                            string getId = "SELECT id from " + GiveAwayName + "_giveaway_members ORDER BY ID DESC limit 1";
                            SQLiteDataReader res = db.Select(getId);
                            while (res.Read())
                            {
                                GiveAwayMembers.Rows[e.RowIndex].Cells[0].Value = res.GetValues()[0];
                            }
                            res.Close();
                        }
                    }
                    else
                    {
                        string update = "UPDATE " + GiveAwayName + "_giveaway_members set username='" + GiveAwayMembers.Rows[e.RowIndex].Cells[1].Value.ToString() + "', name='" + GiveAwayMembers.Rows[e.RowIndex].Cells[2].Value.ToString() + "',entry_count=" + GiveAwayMembers.Rows[e.RowIndex].Cells[3].Value.ToString() + " WHERE id=" + GiveAwayMembers.Rows[e.RowIndex].Cells[0].Value.ToString();
                        db.Insert(update);
                    }
                    db.Close();
                }
            }
        }
        /// <summary>
        /// Obvious but this closes the app when the quit button is picked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Loads the new giveaway form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGiveawayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giveaway ga = new Giveaway(this);
            ga.Show();
            ga.Setup();
        }
        /// <summary>
        /// Removes the user from the giveaway.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.Open();
            GiveAwayMembers.AllowUserToAddRows = false;
            foreach (DataGridViewCell cell in GiveAwayMembers.SelectedCells)
            {
                GiveAwayMembers.Rows[cell.RowIndex].Selected = true;
            }
            foreach (DataGridViewRow row in GiveAwayMembers.SelectedRows)
            {
                GiveAwayMembers.Rows.Remove(row);
                String UID = (String)row.Cells[0].Value;
                String del = "DELETE from " + GiveAwayName + "_giveaway_members WHERE id=" + UID;
                db.Insert(del);
            }
            db.Close();
            GiveAwayMembers.AllowUserToAddRows = true;
        }
        /// <summary>
        /// Selects giveaways from the list of giveaways. Checks there are any first.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectGiveawayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM giveaways where  is_deleted is null ORDER BY ID DESC LIMIT 1";
            Database db = new Database();
            db.Open();
            SQLiteDataReader res = db.Select(query);
            if (res.HasRows)
            {
                GiveAwaySelect Sel = new GiveAwaySelect(this);
                Sel.Show();
            }
            else
            {
                MessageBox.Show("No Giveaways yet! Please create one first");
            }
            res.Close();
            db.Close();
        }
        /// <summary>
        /// Takes you to the configuration page for the current giveaway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configureGiveawayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GiveAwayID == "-1")
            {
                Giveaway ga = new Giveaway(this);
                ga.Show();
                ga.Setup();
            }
            else
            {
                Giveaway ga = new Giveaway(this);
                ga.Show();
                ga.Setup(GiveAwayID);
            }
        }
        /// <summary>
        /// <para>Opens the menu to import data from forms notepad</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fowlImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fowl_Import import = new Fowl_Import(this,GiveAwayID,GiveAwayName);
            import.ShowDialog();
            LoadDetails();
        }
        /// <summary>
        /// Opens the menu to change settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.ShowDialog();
            LoadConfig();
        }
        /// <summary>
        /// Loads all the config data from the database and updates it
        /// </summary>
        private void LoadConfig()
        {
            Database db = new Database();
            db.Open();
            string getSettings = "SELECT setting_name,setting_value FROM settings where can_edit=1";
            SQLiteDataReader setres = db.Select(getSettings);
            
            while (setres.Read())
            {
                String settingName = (String)setres.GetValue(0);
                Int64 settingValue = (Int64)setres.GetValue(1);
                if (settingName == "speed (ms)")
                {
                    wait = settingValue;
                }
                else if(settingName == "loops")
                {
                    loops = settingValue;
                }
            }
        }
        
    }

    public class Entry
    {
        public String ID;
        public String Name;
        public String Username;
        public int Row;
        public Entry(string id, string name, string username, int row)
        {
            ID = id;
            Name = name;
            Username = username;
            Row = row;
        }
    }
    public class Item
    {
        public String itemID;
        public String itemName;
        public Int64 itemCount;
        public Int64 itemsWon;
        public Item(String id, String name, Int64 count, Int64 won)
        {
            itemID = id;
            itemName = name;
            itemCount = count;
            itemsWon = won;
        }
    }
}
