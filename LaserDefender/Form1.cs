using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace LaserDefender
{
    public partial class Form1 : Form
    {
        //make a list capable of storing enemyship
        private List<Enemy> enemies = new List<Enemy>();
        private List<Laser> lasers = new List<Laser>();

        int enemyShipNumber = 0; // used in array to index each enemy
        string playerShipDirection = "up";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.W)) //moves playership  up 
            {
                if (pictureBox1.Top > 0) //check we are not at the very top of the form
                {
                    pictureBox1.Top = pictureBox1.Top - 5; //reducing top, takes us closer to 0 (the absolute top)
                    pictureBox1.Image = Properties.Resources.playerShip; //switch arrow graphic to fav the right direction
                }

            }

            if (e.KeyCode.Equals(Keys.A)) //moves playership left 
            {
                if (pictureBox1.Left > 0) // check the playership is not at very left of the form
                {
                    pictureBox1.Left = pictureBox1.Left - 5;
                    pictureBox1.Image = Properties.Resources.playerShip;
                }
            }

            if (e.KeyCode.Equals(Keys.D)) //moves playership to the right
            {
                if (pictureBox1.Right < this.Width) // check the playership is not at the very right of the form
                {
                    pictureBox1.Left = pictureBox1.Left + 5;
                    pictureBox1.Image = Properties.Resources.playerShip;
                }
            }

            if (e.KeyCode.Equals(Keys.S)) //moves playership down
            {
                if (pictureBox1.Bottom < this.Height - 10) // check the playership is not at the very bottom of the form
                {
                    pictureBox1.Top = pictureBox1.Left + 10;
                    pictureBox1.Image = Properties.Resources.playerShip;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (enemyShipNumber > 9)
            {
                timer1.Enabled = false; //after 10 enemyShip we stop the timer so we do not get any more ducks or an error
                timer2.Enabled = true; // we enable the other timer which controls the enemyShip movemnt
            }

            else
            {
                enemies.Add(new Enemy(this));
                enemyShipNumber++;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            enemies.RemoveAll(enemy => enemy.isDisposed);

            foreach (Enemy enemy in enemies)
            {
                enemy.moveEnemy(this);  //call the moveDucky method

                if (pictureBox1.Bounds.IntersectsWith(enemy.enemyShip.Bounds)) //check for collision between arrow and all enemyship

                {
                    timer2.Enabled = false; //stop all enemies from moving

                    SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Alarm01.wav"); //add sound when you lose
                    simpleSound.Play();
                    MessageBox.Show("you lose");
                    return;
                }

            }

            lasers.RemoveAll(laser => laser.isDisposed);
            foreach (Laser laser in lasers)
            {
                laser.MoveLaser(this);
            }

            foreach (Laser laser in lasers)
            {
                if (laser.d.Bounds.IntersectsWith(enemies.d.Bounds))
                {
                    laser.isDisposed = true;
                    laser.d.Dispose();
                    enemies.isDisposed = true;
                    enemies.d.Dispose();
                }
            }
        }
    }
}
