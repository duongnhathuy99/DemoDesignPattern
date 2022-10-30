using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Animation;
using System.Windows.Forms;

namespace StatePattern
{

    public abstract class NinjaState
    {
        protected Ninja _ninja;

        public void SetPlayer(Ninja ninja)
        {
            this._ninja = ninja;
        }
        public abstract void handleInputKeyUp( Keys key);
        public abstract void handleInputKeyDown( Keys key);
        public abstract void update(int time);
    }

     class idleState : NinjaState
    {
        public override void handleInputKeyDown( Keys key) {
            if (key == Keys.Left || key == Keys.Right)
            {
                //Console.WriteLine("set state run\n");
                _ninja.setState(new runState());
            }
            else if (key == Keys.A)
                _ninja.setState(new attackState());
            else if (key == Keys.Space)
                _ninja.setState(new junmpState());
        }
        public override void handleInputKeyUp( Keys key) { }
        public override void update(int time) { Animations.GetInstance().drawIdle(time); }
    }
     class runState : NinjaState
    {
        public override void handleInputKeyDown( Keys key) {}
        public override void handleInputKeyUp( Keys key) { 
            if (key == Keys.Left || key == Keys.Right) {
                //Console.WriteLine("set state idle\n");
                _ninja.setState(new idleState());
            }
            else if (key == Keys.A)
                _ninja.setState(new attackState());
            else if (key == Keys.Space)
                _ninja.setState(new junmpState());
        }
        public override void update(int time) { Animations.GetInstance().drawRun(time); }
    }
     class attackState : NinjaState
    {
        public override void handleInputKeyDown( Keys key) { }
        public override void handleInputKeyUp( Keys key) { }
        public override void update(int time) { 
            if(Animations.GetInstance().drawAttack(time)==0)
                _ninja.setState(new idleState());
        }
    }
    class junmpState : NinjaState
    {
        public override void handleInputKeyDown(Keys key) { }
        public override void handleInputKeyUp(Keys key) { }
        public override void update(int time)
        {
            if (Animations.GetInstance().drawJump(time) == 0)
                _ninja.setState(new idleState());
        }
    }
}
