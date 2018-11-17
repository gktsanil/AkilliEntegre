using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AkilliEntegre.Model;
using MetroFramework.Forms;

namespace AkilliEntegre
{
    public partial class MainMenu : MetroForm
    {
        Functions func = new Functions();
        WeCart weCart = new WeCart();
        public MainMenu()
        {
            InitializeComponent();
        }

        private void weCartBtn_Click(object sender, EventArgs e)
        {
            func.ShowForm(this.weCart, this);
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", "Programı kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void metroTile19_Click(object sender, EventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            MetroForm wecart = new WeCart();
            func.ShowForm(wecart, this);
        }

        private void hbTile_Click(object sender, EventArgs e)
        {
            MetroForm hbapi = new HBSection();
            func.ShowForm(hbapi, this);
        }
    }
}
