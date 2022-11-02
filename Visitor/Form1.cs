using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visitor
{
    public partial class Form1 : Form
    {
        Graphics g;
        Graphics g1;
        int tile=5;
        Bitmap wizard_fire;
        Bitmap wizard_ice;
        Bitmap backbuffer;
        Bitmap monster;
        int t;
        bool hit=false;
        bool hit2 = false;
        Wizard fire = new WizardFire();
        Wizard ice = new WizardIce();

        Monster green = new SlimeGreen();
        Monster blue = new SlimeBlue();
        public Form1()
        {
            InitializeComponent();
            main();
        }
        void main() {
            g1 = CreateGraphics();
            backbuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = Graphics.FromImage(backbuffer);
            wizard_fire = new Bitmap(Image.FromFile("sprites\\wizard_fire.png"), 377/tile, 410 / tile);
            wizard_ice = new Bitmap(Image.FromFile("sprites\\wizard_ice.png"), 377 / tile, 410 / tile);
            monster = new Bitmap(Image.FromFile("sprites\\Slimes.png"), 774, 4165 );
            label1.Text = "Slime Green:" + green.health + " HP";
            label2.Text = "Slime Blue:"+ blue.health + " HP";
            timer1.Interval = 150;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = fire.hit(green);
            label1.Text = "Slime Green:";
            label1.Text += green.health+" HP";
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
            label4.Text = fire.hit(blue);
            label2.Text = "Slime Blue:";
            label2.Text += blue.health+" HP";
            g.DrawImage(monster, 450, 250, new Rectangle(5, 648, 72, 77), GraphicsUnit.Pixel);
            hit2 = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = ice.hit(blue);
            label2.Text = "Slime Blue:";
            label2.Text += blue.health + " HP";
            g.DrawImage(monster, 450, 250, new Rectangle(5, 648, 72, 77), GraphicsUnit.Pixel);
            hit2 = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            g.DrawImage(wizard_fire, 100, 0);
            g.DrawImage(wizard_ice, 100, 100);
            g.DrawImage(wizard_fire, 100, 200);
            g.DrawImage(wizard_ice, 100, 300);
            if (!hit)
                 g.DrawImage(monster, 450, 50, new Rectangle(8+t%7*72, 72, 72, 72), GraphicsUnit.Pixel);
            if (!hit2)
                g.DrawImage(monster, 450, 250, new Rectangle(10 + t % 7 * 72, 496, 72, 77), GraphicsUnit.Pixel);
            g1.DrawImageUnscaled(backbuffer, 0, 0);
            g.FillRectangle(new SolidBrush(SystemColors.Control), new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            hit = false;
            hit2 = false;
        }
    }
}
