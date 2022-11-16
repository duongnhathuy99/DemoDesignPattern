using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animation;

namespace Visitor___State
{
    public abstract class WizardState
    {
        protected Wizard _wizard;

        public void SetPlayer(Wizard wizard)
        {
            this._wizard = wizard;
        }
        public abstract void hit();
        public abstract void die();
        public abstract void update(int time);
    }

    class idleState : WizardState
    {
        public override void hit()
        {
            _wizard.setState(new attackState());
        }
        public override void die() { }
        public override void update(int time) { 
            if(_wizard is WizardFire)
                Animations.GetInstance().WizardFire_Idle(time,_wizard.x,_wizard.y); 
            else
                Animations.GetInstance().WizardIce_Idle(time, _wizard.x, _wizard.y);
        }
    }
    class attackState : WizardState
    {
        public override void hit() { }
        public override void die()
        {
           
        }
        public override void update(int time) {
            if (_wizard is WizardFire)
            {
                if (Animations.GetInstance().WizardFire_attack(_wizard.x, _wizard.y) == 0)
                    _wizard.setState(new idleState());
            }
            else
                if (Animations.GetInstance().WizardIce_attack(_wizard.x, _wizard.y) == 0)
                    _wizard.setState(new idleState());
        }
    }
    class dieState : WizardState
    {
        public override void hit() { }
        public override void die() { }
        public override void update(int time)
        {
           /* if (Animations.GetInstance().WizardFire_attack(xx,yy) == 0)
                _wizard.setState(new idleState());*/
        }
    }
   
}
