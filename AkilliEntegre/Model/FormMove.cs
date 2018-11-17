using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliEntegre.Model
{
    class FormMove
    {

        public bool mouseDown;
        public Point lastLocation;
        private Form MoveForm;

        public FormMove(Form form)
        {
            this.MoveForm = form;
        }

        public void MoveForm_MouseDown(MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        public void MoveForm_MouseMove(MouseEventArgs e)
        {
            if (mouseDown)
            {
                MoveForm.Location = new Point((MoveForm.Location.X - lastLocation.X) + e.X, (MoveForm.Location.Y - lastLocation.Y + e.Y));

                MoveForm.Update();
            }
        }

        public void MoveForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
