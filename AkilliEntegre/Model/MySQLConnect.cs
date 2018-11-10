using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AkilliEntegre.Model
{
    class MySQLConnect
    {

        private static string Host = "";
        private static string User = "";
        private static string DBname = "";
        private static string Password = "";
        private static string Port = "5432";
        public MySqlDataAdapter baglayici = new MySqlDataAdapter();
        public MySqlCommand komut = new MySqlCommand();
        public DataTable table = new DataTable();
        public MySqlConnection baglan;
        public MySqlDataReader dataReader;

        public MySQLConnect()
        {
            this.SqlConnection();
        }

        private void SqlConnection()
        {
            try
            {
                this.baglan = new MySqlConnection("Server=" + Host + "; Database=" + DBname + "; uid=" + User + "; Password=" + Password + ";Persist Security Info=True;Convert Zero Datetime=True");

            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show(msg.ToString());
                //throw;
            }
        }

        public void CreateMySqlCommand(string myExecuteQuery, MySqlConnection myConnection)
        {
            MySqlCommand myCommand = new MySqlCommand(myExecuteQuery, myConnection);
            myCommand.Connection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
