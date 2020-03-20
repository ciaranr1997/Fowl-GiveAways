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
    /// <summary>
    /// <para>Handles the database connections</para>
    /// </summary>
    public class Database
    {
        
        private SQLiteConnection con;
        String path = Directory.GetCurrentDirectory();
        String name = "fowl.sqlite";
        String connectionstring;
        public Database()
        {
            connectionstring = "Data Source=" + path + "/" + name + ";New=False;MultipleActiveResultSets=True";
            con = new SQLiteConnection(connectionstring);
        }
        /// <summary>
        /// <para>Opens the connection</para>
        /// </summary>
        public void Open()
        {
            con.Open();
        }
        /// <summary>
        /// <para>Runs a command but doesn't return anything, normally used for inserts and updates.</para>
        /// </summary>
        /// <param name="query">The query to run</param>
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
        /// <summary>
        /// <para>Runs a query and returns the result</para>
        /// </summary>
        /// <param name="query">The query to run</param>
        /// <returns></returns>
        public SQLiteDataReader Select(String query)
        {
            
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader res = cmd.ExecuteReader();
            return res;
        }
        /// <summary>
        /// <param>Closes the connection then disposes it</param>
        /// </summary>
        public void Close()
        {
            con.Close();
            con.Dispose();
        }
    }

}
