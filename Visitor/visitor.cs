using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Visitor
{
    
    public abstract class Wizard //Element
    {
        abstract public string hit(Monster monster);
    }

    public abstract class Monster //Visitor
    {
        public int health;
        abstract public string hitBy(WizardFire fire);
        abstract public string hitBy(WizardIce ice);
    }


    public class WizardFire : Wizard //Element 1
    {
        override public string hit(Monster monster)
        {
            return "Wizard fire hit:" + monster.hitBy(this);
        }
    }

    public class WizardIce : Wizard //Element 2
    {
        override public string hit(Monster monster)
        {
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
