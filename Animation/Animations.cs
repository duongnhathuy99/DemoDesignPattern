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
        Bitmap ninja;
        Graphics _g;
        int x = 300;
        int y = 200;
        int lastFrameTime;
        int currentFrame;
        public Animations()
        {
            ninja = new Bitmap(Image.FromFile("Sprite\\ninja.png"), 5400 / ratio, 5722 / ratio);
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
        }
        public int drawJump(int time)
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
        public int drawAttack(int time)
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
    }
}
