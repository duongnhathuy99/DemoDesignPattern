using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Visitor___State
{
    
    public abstract class Wizard  //Element
    {
        public int x,y;
        public WizardState _state = null;
        public Wizard(int x, int y)
        {
            this.x = x;
            this.y = y;
            _state = new idleState();
            _state.SetPlayer(this);
        }
        abstract public string hit(Monster monster);
        public void update(int time)
        {
            _state.update(time);
        }
        public void setState(WizardState state)
        {
            _state = state;
            _state.SetPlayer(this);
        }
    }

    public abstract class Monster //Visitor
    {
        public int health;
        abstract public string hitBy(WizardFire fire);
        abstract public string hitBy(WizardIce ice);
    }


    public class WizardFire : Wizard //Element 1
    {
        public WizardFire(int x ,int y):base(x,y) { }
        override public string hit(Monster monster)
        {
            _state.hit();
            return "Wizard fire hit:" + monster.hitBy(this);
        }
    }

    public class WizardIce : Wizard //Element 2
    {
        public WizardIce(int x, int y):base(x,y) {  }
        override public string hit(Monster monster)
        {
            _state.hit();
            return "Wizard ice hit:"+monster.hitBy(this);
        }
    }

    public class SlimeGreen : Monster //Visitor A
    {
        public SlimeGreen() { health = 100; }
        override public string hitBy(WizardFire fire)
        {
            int hp = -10;
            health += hp;
            return  + hp + "hp";
        }

        override public string hitBy(WizardIce ice)
        {
            int hp = -5;
            health += hp;
            return + hp + "hp";
        }
    }
    public class SlimeBlue : Monster //Visitor B
    {
        public SlimeBlue() { health = 150; }
        override public string hitBy(WizardFire fire)
        {
            int hp = -12;
            health += hp;
            return + hp + "hp";
        }

        override public string hitBy(WizardIce ice)
        {
            int hp = -7;
            health += hp;
            return + hp + "hp";
        }
    }
}
