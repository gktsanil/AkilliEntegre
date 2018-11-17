using AkilliEntegre.Model;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliEntegre
{
    public partial class WeCart : MetroForm
    {
        Functions func = new Functions();
        MySQLConnect conn = new MySQLConnect();
        Export exp = new Export();
        public WeCart()
        {
            InitializeComponent();
        }

        private void backTile_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            func.ShowForm(main, this);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            conn.FillDatatable("SELECT * FROM orders LIMIT 100", this.metroGrid1);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            conn.FillDatatable(metroTextBox1.Text.ToString(), this.metroGrid2);

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            exp.ExcellExport(metroGrid2);
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            exp.ImportExcell(metroGrid2);
        }
    }
}
