using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyweightPattern
{
    public partial class Form1 : Form
    {
        World world = new World();
        Monster mon;

        Bitmap monster;
        Graphics g;
        Graphics g1;
        public Form1()
        {
            InitializeComponent();
            g1=CreateGraphics();
            monster = new Bitmap(Image.FromFile("monster.png"), 384*2, 256 * 2);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            load();
        }
        void load() {
            
            Bitmap tex= new Bitmap(32 * 2, 32 * 2);
            g = Graphics.FromImage(tex);
            g.DrawImage(monster, 0, 0, new Rectangle(  32 * 2, 0, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
            mon = new Monster()
            {
                x = 10,
                y=30,
                type=new TypeMoster() {name="Monster A", color = Color.Red , texture = tex }
            };
            world.addMonster(mon);

            tex = new Bitmap(32 * 2, 32 * 2);
            g = Graphics.FromImage(tex);
            g.DrawImage(monster, 0, 0, new Rectangle(128 * 2, 0, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
            mon = new Monster()
            {
                x = 110,
                y = 30,
                type = new TypeMoster() { name = "Monster B", color = Color.Red, texture = tex }
            };
            world.addMonster(mon);

            
            mon = new Monster()
            {
                x = 210,
                y = 30,
                type = new TypeMoster() { name = "Monster A", color = Color.Red, texture = tex }
            };
            world.addMonster(mon);

            tex = new Bitmap(32 * 2, 32 * 2);
            g = Graphics.FromImage(tex);
            g.DrawImage(monster, 0, 0, new Rectangle(224 * 2, 0, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
            mon = new Monster()
            {
                x = 310,
                y = 30,
                type = new TypeMoster() { name = "Monster C", color = Color.Orange, texture = tex }
            };
            world.addMonster(mon);

            mon = new Monster()
            {
                x = 410,
                y = 30,
                type = new TypeMoster() { name = "Monster C", color = Color.Orange, texture = tex }
            };
            world.addMonster(mon);

            tex = new Bitmap(32 * 2, 32 * 2);
            g = Graphics.FromImage(tex);
            g.DrawImage(monster, 0, 0, new Rectangle(32 * 2, 0, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
            mon = new Monster()
            {
                x = 510,
                y = 30,
                type = new TypeMoster() { name = "Monster A", color = Color.Blue, texture = tex }
            };
            world.addMonster(mon);
            mon = new Monster()
            {
                x = 610,
                y = 30,
                type = new TypeMoster() { name = "Monster A", color = Color.Blue, texture = tex }
            };
            world.addMonster(mon);
            


            for (int i = 0; i < world.GetCountMonster(); i++)
            {
                Label lb=new Label();

                lb.AutoSize = true;
                lb.Location = new Point(100*(i%8), 100*(i/8+1));
                lb.Name = "listlb"+i.ToString();
                lb.Text = world.GetMonster(i).type.name;
                lb.ForeColor = world.GetMonster(i).type.color;
                lb.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); ;
                this.Controls.Add(lb);
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < world.GetCountMonster(); i++)
            {
                g1.DrawImage(world.GetMonster(i).type.texture, world.GetMonster(i).x, world.GetMonster(i).y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap tex = new Bitmap(32 * 2-1, 32 * 2);
            g = Graphics.FromImage(tex);
            
            switch (comboBox1.SelectedIndex) {
                case 0:
                    g.DrawImage(monster, 0, 0, new Rectangle(32 * 2, 0, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
                    break;
                case 1:
                    g.DrawImage(monster, 0, 0, new Rectangle(128 * 2, 0, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
                    break;
                case 2:
                    g.DrawImage(monster, 0, 0, new Rectangle(224 * 2, 0, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
                    break;
                case 3:
                    g.DrawImage(monster, 0, 0, new Rectangle(320 * 2, 0, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
                    break;
                case 4:
                    g.DrawImage(monster, 0, 0, new Rectangle(32 * 2, 128*2, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
                    break;
                case 5:
                    g.DrawImage(monster, 0, 0, new Rectangle(128 * 2, 128*2, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
                    break;
                case 6:
                    g.DrawImage(monster, 0, 0, new Rectangle(224 * 2, 128*2, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
                    break;
                case 7:
                    g.DrawImage(monster, 0, 0, new Rectangle(320 * 2, 128*2, 32 * 2, 32 * 2), GraphicsUnit.Pixel);
                    break;
            }
            Color mau=new Color();
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    mau = Color.Red;
                    break;
                case 1:
                    mau = Color.Blue;
                    break;
                case 2:
                    mau = Color.Gold;
                    break;
                case 3:
                    mau = Color.Orange;
                    break;
                case 4:
                    mau = Color.Green;
                    break;
            }

            Label lb = new Label();
            int i = world.GetCountMonster();
            lb.AutoSize = true;
            lb.Location = new Point(100 * (i % 8), 100 * (i / 8 + 1));
            lb.Name = "listlb" + i.ToString();
            lb.Text = comboBox1.GetItemText(comboBox1.SelectedItem);
            lb.ForeColor = mau;
            lb.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); ;
            this.Controls.Add(lb);
            mon = new Monster()
            {
                x = 100 * (i % 8)+10,
                y = 100 * (i / 8 )+30,
                type = new TypeMoster() { name = comboBox1.GetItemText(comboBox1.SelectedItem), color = mau, texture = tex }
            };
            world.addMonster(mon);
        }
    }
}
