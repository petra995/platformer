using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace platformer
{
    public partial class Form1 : Form
    {
        
        Image playerImg;
        private int currFrame = 0;
        private int currAnimation = 0;
        bool isAnyKeyPressed = false;
        int speed = 2;
        int w = 125;
        int h = 285;
        public Form1()
        {
            
            InitializeComponent();
            
            playerImg = new Bitmap("C:\\adv_chara1.png");
            timer2.Interval = 10;
            timer2.Tick += new EventHandler(updMove);
            timer2.Start();
            timer1.Tick += new EventHandler(update);
            timer1.Interval = 100;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(keyboard);
            this.KeyUp += new KeyEventHandler(free_keyboard);

        }

        private void updMove(object sender, EventArgs e)
        {
            switch (currAnimation)
            {
                case 0:
                    pictureBox1.Location = new Point(pictureBox1.Location.X + speed, pictureBox1.Location.Y);
                    break;
                case 1:
                    pictureBox1.Location = new Point(pictureBox1.Location.X - speed, pictureBox1.Location.Y);
                    break;
                case 3:
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - speed);
                    break;
                case 2:
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + speed);
                    break;
            }
        }

        private void free_keyboard(object sender, KeyEventArgs e)
        {
            isAnyKeyPressed = false;
            switch (e.KeyCode.ToString())
            {
                case "D":
                    currAnimation = 5;
                    break;
                case "A":
                    currAnimation = 6;
                    break;
                case "W":
                    currAnimation = 8;
                    break;
                case "S":
                    currAnimation = 7;
                    break;
            }
            currFrame = 0;
            label1.Text = "LastKey: " + e.KeyCode.ToString();
        }

        private void keyboard(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode.ToString())
            {
                case "D":
                    currAnimation = 0;
                    //pictureBox1.Location = new Point(pictureBox1.Location.X + speed, pictureBox1.Location.Y);
                    break;
                case "A":
                    currAnimation = 1;
                   // pictureBox1.Location = new Point(pictureBox1.Location.X - speed, pictureBox1.Location.Y);
                    break;
                case "W":
                    currAnimation = 3;
                    //pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - speed);
                    break;
                case "S":
                    currAnimation = 2;
                   // pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + speed);
                    break;
            }
            
            isAnyKeyPressed = true;
        }

        private void update(object sender, EventArgs e)
        {
            if (isAnyKeyPressed)
            {
                timer1.Interval = 100;
                playAnimationMove();
                if (currFrame == 11)
                {
                    currFrame = 2;
                }
                
            }
            else
            {
                timer1.Interval = 100;
                playAnimationIdle();
                if (currFrame == 2)
                {
                    currFrame = 0;
                }
                

            }
            currFrame++;
        }
        private void playAnimationIdle()
        {
            if (currAnimation >= 5)
            {
                Image part = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(playerImg, 0, 0, new Rectangle(new Point(75 * currFrame, 170 * (currAnimation-5)), new Size(w, h)), GraphicsUnit.Pixel);
                pictureBox1.Size = new Size(w,h);
                pictureBox1.Image = part;
            }

        }
        private void playAnimationMove()
        {
            if(currAnimation != -1 && currAnimation <= 4)
            {
                Image part = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(playerImg, 0, 0, new Rectangle(new Point(75 * currFrame, 170 * currAnimation), new Size(w, h)), GraphicsUnit.Pixel);
                pictureBox1.Size = new Size(w, h);
                pictureBox1.Image = part;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
