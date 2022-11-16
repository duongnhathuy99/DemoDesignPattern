using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Animation
{
    public class Animations
    {
        private static Animations _instance;
        int ratio = 3;
        int ratio1 = 5;
        Bitmap ninja;
        Bitmap wizard;
        Graphics _g;
        int x = 300;
        int y = 200;
        int lastFrameTime;
        int currentFrame;
        public Animations()
        {
            ninja = new Bitmap(Image.FromFile("sprites\\ninja.png"), 5400 / ratio, 5722 / ratio);
            wizard =new Bitmap(Image.FromFile("sprites\\wizard.png"), 3500 / ratio1, 2650 / ratio1);
        }
        public void setgraphics(Graphics g)
        {
            _g = g;
        }
        public static Animations GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Animations();
            }
            return _instance;
        }
        public void drawIdle(int time)
        {
            _g.DrawImage(ninja, x, y, new Rectangle(time % 10 * 290 / ratio, 2135 / ratio, 290 / ratio, 500 / ratio), GraphicsUnit.Pixel);//idle
        }
        public void drawRun(int time)
        {
               _g.DrawImage(ninja, x, y, new Rectangle((int)time % 10 * 376 / ratio, 4258 / ratio, 376 / ratio, 520 / ratio), GraphicsUnit.Pixel);//run
        }
        public void drawAction(int time)
        {
            //g.DrawImage(ninja, 0, 0, new Rectangle((int)time % 10 * 524/ ratio, 0, 524/ ratio, 565/ ratio), GraphicsUnit.Pixel);//attack
            //g.DrawImage(ninja, 0, 0, new Rectangle((int)time % 10 * 361 / ratio, 565/ratio, 361 / ratio, 497 / ratio), GraphicsUnit.Pixel);//climp
            //g.DrawImage(ninja, 0, 0, new Rectangle((int)time % 10 * 290 / ratio, 2135 / ratio, 290 / ratio, 500 / ratio), GraphicsUnit.Pixel);//idle
            //g.DrawImage(ninja, 0, 0, new Rectangle((int)time % 10 * 376 / ratio, 4258 / ratio, 376 / ratio, 520 / ratio), GraphicsUnit.Pixel);//run
            //g.DrawImage(ninja, 0, 0, new Rectangle((int)time % 10 * 399 / ratio, 2637 / ratio, 399 / ratio, 543 / ratio), GraphicsUnit.Pixel);//jump
            //g.DrawImage(ninja, 0, 0, new Rectangle((int)time % 10 * 527 / ratio, 1062 / ratio, 527 / ratio, 599 / ratio), GraphicsUnit.Pixel);//dead
            //g.DrawImage(ninja, 0, 0, new Rectangle((int)time % 10 * 397 / ratio, 4778 / ratio, 397 / ratio, 401 / ratio), GraphicsUnit.Pixel);//slide

            /*_g.DrawImage(wizard, 0, 0, new Rectangle((int)time % 5 * 377, 0, 377, 410), GraphicsUnit.Pixel);//wizard_fire idle
            _g.DrawImage(wizard, 0, 0, new Rectangle((int)time % 5 * 652, 410, 652, 476), GraphicsUnit.Pixel);//wizard_fire hit
            _g.DrawImage(wizard, 0, 0, new Rectangle((int)time % 5 * 380, 886, 380, 425), GraphicsUnit.Pixel);//wizard_fire die
            _g.DrawImage(wizard, 0, 0, new Rectangle((int)time % 5 * 381, 1300, 381, 404), GraphicsUnit.Pixel);//wizard_ice idle
            _g.DrawImage(wizard, 0, 0, new Rectangle((int)time % 5 * 698, 1705, 698, 483), GraphicsUnit.Pixel);//wizard_ice hit
            _g.DrawImage(wizard, 0, 0, new Rectangle((int)time % 5 * 373, 2190, 373, 411), GraphicsUnit.Pixel);//wizard_ice ice*/

        }
        public int drawJump()
        {
            int now = Environment.TickCount;
            if (currentFrame == -1)
            {
                currentFrame = 0;
                lastFrameTime = now;
            }
            else
            {
                if (now - lastFrameTime > 10)
                {
                    currentFrame++;
                    lastFrameTime = now;
                }
            }
            if (currentFrame < 5)
                y-=20;
            else
                y+=20;
            _g.DrawImage(ninja, x, y, new Rectangle(currentFrame * 399 / ratio, 2637 / ratio, 399 / ratio, 543 / ratio), GraphicsUnit.Pixel);//jump
            if (currentFrame == 9)
            {
                currentFrame = 0;
                y = 200;
                return 0;
            }
            else
                return 1;
        }
        public int drawAttack()
        {
            int now = Environment.TickCount;
            if (currentFrame == -1)
            {
                currentFrame = 0;
                lastFrameTime = now;
            }
            else
            {
                if (now - lastFrameTime > 10)
                {
                    currentFrame++;
                    lastFrameTime = now;
                }
            }
            _g.DrawImage(ninja, x, y-5, new Rectangle((int)currentFrame  * 524 / ratio, 0, 524 / ratio, 565 / ratio), GraphicsUnit.Pixel);//attack
            if (currentFrame == 9)
            {
                currentFrame = 0;
                return 0;
            }
            else
                return 1;
        }

        public void WizardFire_Idle(int time,int xx, int yy)
        {
            _g.DrawImage(wizard, xx, yy, new Rectangle((int)time % 5 * 377 / ratio1, 0, 377 / ratio1, 410 / ratio1), GraphicsUnit.Pixel);//wizard_fire idle
        }
        public int WizardFire_attack( int xx, int yy)
        {

            int now = Environment.TickCount;
            if (currentFrame == -1)
            {
                currentFrame = 0;
                lastFrameTime = now;
            }
            else
            {
                if (now - lastFrameTime > 20)
                {
                    currentFrame++;
                    lastFrameTime = now;
                }
            }
            _g.DrawImage(wizard, xx-7, yy-5, new Rectangle(currentFrame  * 652 / ratio1, 410 / ratio1, 652 / ratio1, 476 / ratio1), GraphicsUnit.Pixel);//wizard_fire hit
            if (currentFrame == 4)
            {
                currentFrame = 0;
                return 0;
            }
            else
                return 1;
           
        }
        public void WizardIce_Idle(int time, int xx, int yy)
        {
            _g.DrawImage(wizard, xx, yy, new Rectangle(time % 5 * 381 / ratio1, 1300 / ratio1, 381 / ratio1, 404 / ratio1), GraphicsUnit.Pixel);//wizard_ice idle
        }
        public int WizardIce_attack(int xx, int yy)
        {

            int now = Environment.TickCount;
            if (currentFrame == -1)
            {
                currentFrame = 0;
                lastFrameTime = now;
            }
            else
            {
                if (now - lastFrameTime > 20)
                {
                    currentFrame++;
                    lastFrameTime = now;
                }
            }
            _g.DrawImage(wizard, xx-5, yy-5, new Rectangle(currentFrame % 5 * 698 / ratio1, 1705 / ratio1, 698 / ratio1, 483 / ratio1), GraphicsUnit.Pixel);//wizard_ice hit
            if (currentFrame == 4)
            {
                currentFrame = 0;
                return 0;
            }
            else
                return 1;

        }
    }
}
