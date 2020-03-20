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
    public partial class GiveAwaySelect : Form
    {
        private Form1 MyParent;
        public GiveAwaySelect(Form1 callingform)
        {
            MyParent = callingform;
            InitializeComponent();
            Database db = new Database();
            db.Open();
            string query = "SELECT id,month FROM giveaways ORDER BY id desc";
            SQLiteDataReader res = db.Select(query);
            if (res.HasRows)
            {
                while (res.Read())
                {
                    giveAwaySel.Items.Add(res.GetValues()[0].ToString()+" | "+res.GetValues()[1].ToString());
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            String item = giveAwaySel.Items[giveAwaySel.SelectedIndex].ToString();
            String GAId = item.Split('|')[0].Replace(" ","");
            MyParent.GiveAwayDetails = GAId;
            this.Close();
        }
    }
}
