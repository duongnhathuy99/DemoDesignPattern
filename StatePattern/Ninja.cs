using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace StatePattern
{
    public class Ninja
    {
        NinjaState _state = null;

        public Ninja() { 
            _state = new idleState();
            _state.SetPlayer(this);
        }
        public void handleInputKeyDown(Keys key)
        {
            _state.handleInputKeyDown(key);
        }
        public void handleInputKeyUp(Keys key)
        {
            _state.handleInputKeyUp( key);
        }
        public void update(int time)
        {
            _state.update(time);
        }
        public void setState(NinjaState state)
        {
            _state = state;
            _state.SetPlayer(this);
        }
    }
}
