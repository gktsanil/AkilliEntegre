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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form hb = new HBForm();
            Form lg = new LoginForm();
            this.ShowForm(hb, lg);
        }

        private void ShowForm(Form newForm, Form oldForm)
        {
            newForm.Show();
            oldForm.Hide();
        }
    }
}
