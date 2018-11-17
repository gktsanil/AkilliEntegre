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

namespace AkilliEntegre
{
    public partial class LoginForm : Form
    {
        Functions func = new Functions();

        public LoginForm()
        {
            InitializeComponent();
            func.RoundPictureBox(this.logoPB);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form mm = new MainMenu();
            this.ShowForm(mm, this);
        }

        private void ShowForm(Form newForm, Form oldForm)
        {
            newForm.Show();
            oldForm.Hide();
        }
    }
}
