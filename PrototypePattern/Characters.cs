using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PrototypePattern
{
    public interface IPrototype
    {
        IPrototype ShallowClone();
        IPrototype DeepClone();
    }
    public class Transformation : IPrototype
    {
        public int power;
        public Bitmap bitmap;
        public IPrototype ShallowClone()
        {
            return (IPrototype)MemberwiseClone();
        }
        public IPrototype DeepClone()
        {
            Transformation tran = (Transformation)this.ShallowClone();
            return tran;
        }
    }
    public class Characters : IPrototype
    {
        public string name;
        public int strength;
        public int health;
        public Transformation _transformation;
        public IPrototype ShallowClone()
        {
            return (Characters)this.MemberwiseClone();
        }
        public IPrototype DeepClone()
        {
            Characters cha = (Characters)this.ShallowClone();
            cha._transformation = (Transformation)this._transformation.ShallowClone();
            return cha;
        }
    }

}
