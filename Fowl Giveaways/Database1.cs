using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Fowl_Giveaways
{

    public class Database
    {
        
        private SQLiteConnection con;
        String path = Directory.GetCurrentDirectory();
        String name = "fowl.sqlite";
        String connectionstring;
        public Database()
        {
            connectionstring = "Data Source=" + path + "/" + name + ";New=False";
            con = new SQLiteConnection(connectionstring);
        }

        public void Open()
        {
            con.Open();
        }
        public void Insert(String query)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(query);
                MessageBox.Show(ex.ToString());
            }
        }
        public SQLiteDataReader Select(String query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader res = cmd.ExecuteReader();
            return res;
            
        }
        public void Close()
        {
            con.Close();
            con.Dispose();
        }
    }

}
