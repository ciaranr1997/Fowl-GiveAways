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
    public partial class Config : Form
    {
        /// <summary>
        /// Loads all config options from the database
        /// </summary>
        public Config()
        {
            InitializeComponent();
            Database db = new Database();
            db.Open();
            string getSettings = "SELECT setting_name,setting_value FROM settings where can_edit=1";
            SQLiteDataReader setres = db.Select(getSettings);
            settings.AllowUserToAddRows = true;
            while (setres.Read())
            {
                DataGridViewRow row = (DataGridViewRow)settings.Rows[0].Clone();
                row.Cells[0].Value = setres.GetValues()[0].ToString();
                row.Cells[1].Value = setres.GetValues()[1].ToString();
                settings.Rows.Add(row);
            }
            settings.AllowUserToAddRows = false;
            db.Close();
        }
        /// <summary>
        /// Update the config details in real time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (settings.RowCount > 1)
            {
                String settingName = (String)settings.Rows[e.RowIndex].Cells[0].Value;
                String settingValue = (String)settings.Rows[e.RowIndex].Cells[1].Value;
                String updateQuery = "UPDATE settings set setting_value='" + settingValue + "' where setting_name='" + settingName + "'";
                Database db = new Database();
                db.Open();
                db.Insert(updateQuery);
                db.Close();
            }
        }
    }
}
