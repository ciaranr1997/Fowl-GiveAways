using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fowl_Giveaways
{
    public partial class Giveaway : Form
    {
        String GiveAwayName;
        private Form1 MyParent;
        private string GiveAwayId = "";
        public Giveaway(Form1 callingform)
        {
            InitializeComponent();
            MyParent = callingform;
        }

        public void Setup(String GiveAway="")
        {
            if (GiveAway != "")
            {
                GiveAwayId = GiveAway;
                Database db = new Database();
                db.Open();
                SQLiteDataReader res = db.Select("SELECT month FROM giveaways WHERE id=" + GiveAwayId);
                while (res.Read())
                {
                    GiveAwayName = res.GetValues()[0].ToString();
                }
                res.Close();
                this.Text = GiveAwayName;
                GAName.Text = GiveAwayName;
                //load data from giveaway
                this.Text = "";
                GAName.ReadOnly = true;
                btnCreate.Hide();
                btnDelete.Show();
                //load in items
                SQLiteDataReader items = db.Select("SELECT id,item_name,quantity FROM giveaway_items where giveaway="+GiveAwayId);
                if (items.HasRows)
                {
                    while (items.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)GiveAwayItems.Rows[0].Clone();
                        row.Cells[0].Value = items.GetValues()[0].ToString();
                        row.Cells[1].Value = items.GetValues()[1].ToString();
                        row.Cells[2].Value = items.GetValues()[2].ToString();
                        GiveAwayItems.Rows.Add(row);
                    }
                }
                db.Close();
            }
            else
            {
                GiveAwayName = DateTime.Now.ToString("MMMM_yy");
                this.Text = GiveAwayName;
                GAName.Text = GiveAwayName;
                btnCreate.Show();
                btnDelete.Hide();
            }
        }

        private void GiveAwayItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (GiveAwayItems.RowCount > 1)
            {
                if (e.ColumnIndex == 1 && GiveAwayItems.Rows[e.RowIndex].Cells[2].Value == null)
                {
                    GiveAwayItems.Rows[e.RowIndex].Cells[2].Value = 1;
                }
                if (GiveAwayId != "")
                {//we want to update these in real time
                    Database db = new Database();
                    db.Open();
                    if (GiveAwayItems.Rows[e.RowIndex].Cells[0].Value == null)
                    {
                        if (GiveAwayItems.Rows[e.RowIndex].Cells[1].Value != null && GiveAwayItems.Rows[e.RowIndex].Cells[2].Value != null)
                        {
                            string insert = "INSERT INTO giveaway_items (giveaway,item_name,quantity) VALUES(" + GiveAwayId+",'"+ GiveAwayItems.Rows[e.RowIndex].Cells[1].Value.ToString()+ "',"+ GiveAwayItems.Rows[e.RowIndex].Cells[2].Value.ToString() + ")";
                            db.Insert(insert);
                            string getId = "SELECT id from giveaway_items ORDER BY ID DESC LIMIT 1";
                            SQLiteDataReader res = db.Select(getId);
                            while (res.Read())
                            {
                                GiveAwayItems.Rows[e.RowIndex].Cells[0].Value = res.GetValues()[0];
                            }
                            res.Close();
                        }
                        else
                        {
                            MessageBox.Show("You've not supplied all the values for this row :(");
                        }
                    }
                    else
                    {
                        string update = "UPDATE giveaway_items set item_name='" + GiveAwayItems.Rows[e.RowIndex].Cells[1].Value.ToString() + "', quantity=" + GiveAwayItems.Rows[e.RowIndex].Cells[2].Value.ToString() +" WHERE id=" + GiveAwayItems.Rows[e.RowIndex].Cells[0].Value.ToString();
                        db.Insert(update);
                    }
                    db.Close();
                }

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (GAName.Text == "")
            {
                MessageBox.Show("Please enter a name for the giveaway");
            }
            else
            {
                GiveAwayName = GAName.Text;
                int itemCount = GiveAwayItems.RowCount - 1;
                string createGA = "INSERT INTO giveaways (month,item_count,allow_multi) VALUES ('" + GiveAwayName+"',0,0)";
                Database db = new Database();
                db.Open();
                db.Insert(createGA);
                SQLiteDataReader res = db.Select("SELECT id FROM giveaways ORDER BY ID DESC LIMIT 1");
                if (res.HasRows)
                {
                    while (res.Read())
                    {
                        GiveAwayId = res.GetValues()[0].ToString();
                    }
                    this.Text = GiveAwayName;
                    res.Close();
                }
                if (itemCount>0)
                {
                    string addItem = "";
                    //insert items
                    foreach (DataGridViewRow row in GiveAwayItems.Rows)
                    {
                        if (row.Cells[0] != null&& row.Cells[0].Value!=null)
                        {
                            addItem = "INSERT INTO giveaway_items (giveaway,item_name,quantity) VALUES (" + GiveAwayId + ",'" + row.Cells[1].Value.ToString() + "'," + row.Cells[2].Value.ToString() + ")";
                            db.Insert(addItem);
                        }
                    }
                }
                string GACreate = "CREATE TABLE \""+GiveAwayName+"_giveaway_members\" ("
                                    + "	\"id\"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                                    + "	\"name\"		varchar(200),"
                                    + "	\"username\"	varchar(200),"
                                    + "	\"entry_count\"	INTEGER,"
                                    + "	\"winner\"	INTEGER"
                                + ");";
                db.Insert(GACreate);
                db.Close();
                this.MyParent.GiveAwayDetails = GiveAwayId;
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}


