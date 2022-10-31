using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototypePattern
{
    public partial class Form1 : Form
    {
        Characters s1 = new Characters();
        Characters s2 /*= new Characters()*/;
        Characters s3 /*= new Characters()*/;
        Graphics g;
        Graphics g1;
        Bitmap buffer;
        public Form1()
        {
            InitializeComponent();
            
            //g.DrawImageUnscaled(s1._transformation.bitmap,0,0);

            s1 = new Characters()
            {
                health = 100,
                strength = 10,
                name = "Songoku",
                _transformation = new Transformation()
                {
                    power = 50,
                    bitmap = new Bitmap(Image.FromFile("saiyan.png"), 150, 300),
                }
            };
            s2 = (Characters)s1.ShallowClone();
            s3 = (Characters)s1.DeepClone();


            comboBox1.SelectedIndex = 0;
            g1 = CreateGraphics();
            buffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = Graphics.FromImage(buffer);
            load();
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            // s2 = (Characters)s1.ShallowClone();
            s2.name = textBox1.Text;
            s2.strength = int.Parse(textBox2.Text);
            s2.health = int.Parse(textBox3.Text);
            s2._transformation.power = int.Parse(textBox4.Text);
            Load();
        }*/

        /*private void button3_Click(object sender, EventArgs e)
        {
            //s3 = (Characters)s1.DeepClone();
            s3.name = textBox12.Text;
            s3.strength = int.Parse(textBox11.Text);
            s3.health = int.Parse(textBox10.Text);
            s3._transformation.power = int.Parse(textBox9.Text);
            Load();
        }*/
        
        private void button2_Click(object sender, EventArgs e)
        {
            s1.name=textBox8.Text  ;
            s1.strength = int.Parse(textBox7.Text);
            s1.health = int.Parse(textBox6.Text);
            s1._transformation.power = int.Parse(textBox5.Text);
            if (comboBox1.SelectedIndex == 0)
                s1._transformation.bitmap = new Bitmap(Image.FromFile("saiyan.png"), 150, 300);
            else if(comboBox1.SelectedIndex == 1)
                s1._transformation.bitmap = new Bitmap(Image.FromFile("saiyanBlue.png"), 150, 300);
            else
                s1._transformation.bitmap = new Bitmap(Image.FromFile("saiyanGod.png"), 150, 300);
            g.FillRectangle(new SolidBrush(SystemColors.Control), new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            load();
            g1.DrawImage(buffer, 0, 0);
        }
        void load()
        {
            if (s2 != null)
            {
                textBox1.Text = s2.name;
                textBox2.Text = s2.strength.ToString();
                textBox3.Text = s2.health.ToString();
                textBox4.Text = s2._transformation.power.ToString();
            }
            if (s3 != null)
            {
                textBox12.Text = s3.name;
                textBox11.Text = s3.strength.ToString();
                textBox10.Text = s3.health.ToString();
                textBox9.Text = s3._transformation.power.ToString();
            }
            if (s1 != null)
            {
                textBox8.Text = s1.name;
                textBox7.Text = s1.strength.ToString();
                textBox6.Text = s1.health.ToString();
                textBox5.Text = s1._transformation.power.ToString();
            }
            g.DrawImage(s1._transformation.bitmap, 460, 210);
            g.DrawImage(s2._transformation.bitmap, 80, 210);
            g.DrawImage(s3._transformation.bitmap, 850, 210);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(buffer, 0, 0);
        }
    }
}
