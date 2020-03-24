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
    public partial class Winners : Form
    {
        private String GiveAwayID;
        private String GiveAwayName;
        public Winners(String GAID)
        {
            InitializeComponent();
            GiveAwayID = GAID;
            Database db = new Database();
            db.Open();
            SQLiteDataReader res = db.Select("SELECT month FROM giveaways WHERE id=" + GiveAwayID);
            while (res.Read())
            {
                GiveAwayName = res.GetValues()[0].ToString();
            }
            res.Close();
            db.Close();
            this.Text = GiveAwayName;
            LoadWinners();
        }
        public void LoadWinners()
        {
            Database db = new Database();
            db.Open();
            string winnerSel = "SELECT "+GiveAwayName+"_giveaway_members.username, giveaway_items.item_name " 
                                + "from " + GiveAwayName + "_giveaway_members "
                                + "inner join giveaway_items on " + GiveAwayName + "_giveaway_members.winner = giveaway_items.id "
                                + "WHERE winner is not null ORDER BY giveaway_items.id ASC";

            SQLiteDataReader res = db.Select(winnerSel);

            if (res.HasRows)
            {
                String winnerName;
                String itemWon;
                while (res.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)WinnerGrid.Rows[0].Clone();
                    winnerName = (String)res.GetValue(0);
                    itemWon = (String)res.GetValue(1);
                    row.Cells[0].Value = winnerName;
                    row.Cells[1].Value = itemWon;
                    WinnerGrid.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("No Winners");
            }
            WinnerGrid.AllowUserToAddRows = false;
            res.Close();
            db.Close();
        }
    }
}
