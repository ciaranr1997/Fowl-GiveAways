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
    public partial class Fowl_Import : Form
    {
        MainForm MyParent;
        String GiveAwayID;
        String GiveAwayName;
        public Fowl_Import(MainForm parent, String gad, String gan)
        {
            InitializeComponent();
            MyParent = parent;
            GiveAwayID = gad;
            GiveAwayName = gan;
        }
        /// <summary>
        /// <para>Load the data from FowlPlay's notepad into the database.</para>
        /// <para>Only really needed for first run but still useful.</para>
        /// <para>Data is in the format NAME x ENTRIES</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            String data = importList.Text;
            String[] lines = data.Split(new[] { Environment.NewLine },StringSplitOptions.None);
            String insert = "";
            Database db = new Database();
            db.Open();
            String dups = "";
            foreach (String line in lines)
            {
                string[] dparams = line.Split(new string[] { " x " },StringSplitOptions.None);

                if (dparams.Length > 1)
                {
                    dparams[0] = dparams[0].Replace(" ","");
                    dparams[1] = dparams[1].Replace(" ","");
                    string dupcheck = "SELECT * from " + GiveAwayName + "_giveaway_members where username='" + dparams[0] + "' or name='" + dparams[0] + "'";
                    SQLiteDataReader dupres = db.Select(dupcheck);
                    if (dupres.HasRows)
                    {
                        dups += dparams[0] + ",";
                    }
                    else
                    {
                        insert = "INSERT INTO " + GiveAwayName + "_giveaway_members (username,name,entry_count) values('" + dparams[0] + "','" + dparams[0] + "'," + dparams[1] + ")";
                        db.Insert(insert);
                    }
                    dupres.Close();
                }
            }
            db.Close();
            if (dups != "")
            {
                MessageBox.Show(dups, "Duplicates Found!");
            }
            else
            {
                MessageBox.Show("All members added without issue :)");
            }
            this.Close();
        }
    }
}
