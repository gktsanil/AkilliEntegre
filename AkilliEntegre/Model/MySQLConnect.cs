using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AkilliEntegre.Model
{
    class MySQLConnect
    {

        private static string Host = "/*Your MySql Host*/";
        private static string User = "/*Your MySql Username*/";
        private static string DBname = "/*Your DBName*/";
        private static string Password = "/*Your MySql Password*/";
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

        public void FillDatatable(String query, DataGridView view)
        {
            this.komut.CommandText = query;
            this.komut.Connection = this.baglan;

            this.baglayici.SelectCommand = this.komut;
            this.baglan.Open();
            this.baglayici.Fill(this.table);
            this.baglan.Close();
            view.DataSource = null;
            view.Refresh();
            view.DataSource = this.table;
            this.baglan.Close();

        }
    }
}
