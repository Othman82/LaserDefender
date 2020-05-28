using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;  //needed for the picturebox

namespace LaserDefender
{
    class Laser
    {
        public PictureBox laser; //the laser will be inside a picture box
        private int xPos, yPos;
        public Boolean isDisposed = false;

        public object Bounds { get; internal set; }

        public Laser(Form f, PictureBox playerShip)
        {

            laser = new PictureBox();
            //set the laser's appearance
            laser.Width = 3;
            laser.Height = 3;
            laser.BackColor = Color.Red;
            laser.Visible = false;

            //set start position of the laser

            yPos = playerShip.Top + 3;
            xPos = playerShip.Left + (playerShip.Width / 2);

            laser.Location = new Point(xPos, yPos);
            f.Controls.Add(laser);
        }

        public void MoveLaser(Form f)
        {
            laser.Visible = true;
            yPos = yPos - 9;

            if (yPos < 0)
            {
                laser.Dispose();
                isDisposed = true;
            }
            laser.Location = new Point(xPos, yPos);


        }
    }
}
