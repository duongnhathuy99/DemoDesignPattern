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

namespace StatePattern
{
    public partial class Form1 : Form
    {
        int time;
        Bitmap buffer;
        Graphics g;
        Graphics g1;
        Ninja n= new Ninja();
        public Form1()
        {
            InitializeComponent();
            g1 = CreateGraphics();
            buffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = Graphics.FromImage(buffer);
            Animations.GetInstance().setgraphics(g);
            timer1.Interval = 50;
        }
        void Render()
        {
            n.update(time);
            g1.DrawImageUnscaled(buffer, 0,0);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0 , this.ClientSize.Width, this.ClientSize.Height));
        }
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            Render();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            n.handleInputKeyDown(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            n.handleInputKeyUp(e.KeyCode);
        }
    }
}
