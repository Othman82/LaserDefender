using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //needed for pictureboxes to be recognised
using System.Drawing; //needed for point to be recognised

namespace LaserDefender
{
    public class Enemy
    {
        public PictureBox enemyShip; //create a global variable enemyShip of type picturebox.
        private int xPos, yPos; //determines the x and y position of the enemyShip
        private int speed;
        private string directionOfEnemy = "right";
        public Boolean isDisposed = false;

        Random random = new Random();

        public static object Bounds { get; internal set; }

        public Enemy(Form f)
        {
            //this is a constructor. A aconstructor has the same name as the class

            enemyShip = new PictureBox(); //create a new instance of a picturebox

            //set the appearence of enemyShip
            enemyShip.Width = 50;
            enemyShip.Height = 50;
            enemyShip.Image = LaserDefender.Properties.Resources.enemyShip; //set image to enemyShip image
            enemyShip.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyShip.Visible = false;

            yPos = random.Next(0, 300); //random position of duck on y axis
            xPos = 0;
            enemyShip.Location = new Point(xPos, yPos); //x and y position of enemyShip for starting
            speed = random.Next(3, 15); //random speed of the duck
            f.Controls.Add(enemyShip); //needed to add the control to form

            //end constructor
        }

        public void moveEnemy(Form f)
        {
            enemyShip.Visible = true; //make enemyShip visible
            if (directionOfEnemy == "right") //check which way the enemyship is going
            {
                if (enemyShip.Right > f.Width) //if far right of screen change its direction
                {
                    directionOfEnemy = "left";
                }

                else
                {
                    xPos = xPos + speed; //move enemyship
                    enemyShip.Location = new Point(xPos, yPos);
                }
            }

            if (directionOfEnemy == "left") //check which way the enemyship is going
            {
                if (enemyShip.Right < 0)
                {
                    directionOfEnemy = "right";
                }

                else
                {
                    xPos = xPos - speed; //move enemyship
                    enemyShip.Location = new Point(xPos, yPos);
                }
            }
        }
    }
}