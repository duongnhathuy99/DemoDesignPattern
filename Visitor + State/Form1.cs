using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animation;
using System.Windows.Forms;

namespace Visitor___State
{
    public partial class Form1 : Form
    {
        Graphics g;
        Graphics g1;
        Bitmap backbuffer;
        Bitmap monster;
        int t;
        bool hit = false;
        bool hit2 = false;
        Wizard fire = new WizardFire(100,0);
        Wizard ice = new WizardIce(100,100);
        Wizard fire1 = new WizardFire(100, 200);
        Wizard ice1 = new WizardIce(100, 300);
        Monster green = new SlimeGreen();
        Monster blue = new SlimeBlue();
        public Form1()
        {
            InitializeComponent();
            main();
        }
        void main()
        {
            g1 = CreateGraphics();
            backbuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = Graphics.FromImage(backbuffer);
            Animations.GetInstance().setgraphics(g);
            monster = new Bitmap(Image.FromFile("sprites\\Slimes.png"), 774, 4165);
            label1.Text = "Slime Green:" + green.health + " HP";
            label2.Text = "Slime Blue:" + blue.health + " HP";
            timer1.Interval = 150;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = fire.hit(green);
            label1.Text = "Slime Green:";
            label1.Text += green.health + " HP";
            g.DrawImage(monster, 450, 50, new Rectangle(0, 221, 72, 77), GraphicsUnit.Pixel);
            hit = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = ice.hit(green);
            label1.Text = "Slime Green:";
            label1.Text += green.health + " HP";
            g.DrawImage(monster, 450, 50, new Rectangle(0, 221, 72, 77), GraphicsUnit.Pixel);
            hit = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = fire1.hit(blue);
            label2.Text = "Slime Blue:";
            label2.Text += blue.health + " HP";
            g.DrawImage(monster, 450, 250, new Rectangle(5, 648, 72, 77), GraphicsUnit.Pixel);
            hit2 = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = ice1.hit(blue);
            label2.Text = "Slime Blue:";
            label2.Text += blue.health + " HP";
            g.DrawImage(monster, 450, 250, new Rectangle(5, 648, 72, 77), GraphicsUnit.Pixel);
            hit2 = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            fire.update(t);
            ice.update(t);
            fire1.update(t);
            ice1.update(t);
            if (!hit)
                g.DrawImage(monster, 450, 50, new Rectangle(8 + t % 7 * 72, 72, 72, 72), GraphicsUnit.Pixel);
            if (!hit2)
                g.DrawImage(monster, 450, 250, new Rectangle(10 + t % 7 * 72, 496, 72, 77), GraphicsUnit.Pixel);

          /*  g.FillRectangle(new SolidBrush(Color.White), 550, 40, 100 * 0.7f, 7);
            if (fire.power < 50)
            g.FillRectangle(new SolidBrush(Color.Blue), 550, 40, fire.power * 0.7f, 7);
           else if(fire.power < 100)
            g.FillRectangle(new SolidBrush(Color.BlueViolet), 550, 40, fire.power * 0.7f, 7); 
            else
                if(t%3==0)
                g.FillRectangle(new SolidBrush(Color.Red), 550, 40, 100 * 0.7f, 7);
            else if (t % 3 == 1)
                g.FillRectangle(new SolidBrush(Color.Orange), 550, 40, 100 * 0.7f, 7);
            else
                g.FillRectangle(new SolidBrush(Color.Aqua), 550, 40, 100 * 0.7f, 7);*/

            g1.DrawImageUnscaled(backbuffer, 0, 0);
            g.FillRectangle(new SolidBrush(SystemColors.Control), new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            hit = false;
            hit2 = false;
        }

       
    }
}
