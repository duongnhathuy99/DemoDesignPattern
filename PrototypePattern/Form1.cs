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
        Characters char1; 
        Characters char2;
        Characters char3;
        Graphics g;
        Graphics g1;
        Bitmap buffer;
        public Form1()
        {
            InitializeComponent();

            char1 = new Characters()
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
            char2 = (Characters)char1.ShallowClone();
            char3 = (Characters)char1.DeepClone();


            comboBox1.SelectedIndex = 0;
            g1 = CreateGraphics();
            buffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = Graphics.FromImage(buffer);
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char1.name=textBox8.Text  ;
            char1.strength = int.Parse(textBox7.Text);
            char1.health = int.Parse(textBox6.Text);
            char1._transformation.power = int.Parse(textBox5.Text);
            if (comboBox1.SelectedIndex == 0)
                char1._transformation.bitmap = new Bitmap(Image.FromFile("saiyan.png"), 150, 300);
            else if(comboBox1.SelectedIndex == 1)
                char1._transformation.bitmap = new Bitmap(Image.FromFile("saiyanBlue.png"), 150, 300);
            else
                char1._transformation.bitmap = new Bitmap(Image.FromFile("saiyanGod.png"), 150, 300);
            g.FillRectangle(new SolidBrush(SystemColors.Control), new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            load();
            g1.DrawImage(buffer, 0, 0);
        }
        void load()
        {
            if (char2 != null)
            {
                textBox1.Text = char2.name;
                textBox2.Text = char2.strength.ToString();
                textBox3.Text = char2.health.ToString();
                textBox4.Text = char2._transformation.power.ToString();
            }
            if (char3 != null)
            {
                textBox12.Text = char3.name;
                textBox11.Text = char3.strength.ToString();
                textBox10.Text = char3.health.ToString();
                textBox9.Text = char3._transformation.power.ToString();
            }
            if (char1 != null)
            {
                textBox8.Text = char1.name;
                textBox7.Text = char1.strength.ToString();
                textBox6.Text = char1.health.ToString();
                textBox5.Text = char1._transformation.power.ToString();
            }
            g.DrawImage(char1._transformation.bitmap, 460, 210);
            g.DrawImage(char2._transformation.bitmap, 80, 210);
            g.DrawImage(char3._transformation.bitmap, 850, 210);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(buffer, 0, 0);
        }
    }
}
