using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlyweightPattern
{
    public class World
    {
        private TypeMonsterFactory factory=new TypeMonsterFactory();
        private List<Monster> Monsters = new List<Monster>();
        public void addMonster(Monster monster)
        {
            monster.type = factory.GetTypeMonster(monster.type);
            
            Monsters.Add(monster);
        }
        public Monster GetMonster(int i) { return Monsters[i]; }
        public int GetCountMonster() { return Monsters.Count; }

    }
    public class TypeMonsterFactory
    {
        private Dictionary<String, TypeMoster> typeMonsters = new Dictionary<String, TypeMoster>();
       
        public TypeMoster GetTypeMonster(TypeMoster type)
        {
            //TypeMoster typeMonster = new TypeMoster();
            string key = type.GetKeyTypeMonster();
            if (typeMonsters.ContainsKey(key))//new ton tai thi lay trong typeMosters ra
            {
                type = typeMonsters[key];
                Console.WriteLine("ton tai nen lay trong typeMosters ra");
            }
            else 
            {
                typeMonsters.Add(key, type); //neu khong thi them typeMoster moi
                Console.WriteLine("khong ton tai nen them typeMoster moi");
            }
            return type;
        }
    }
    public  class Monster
    {
        public int x;
        public int y;
        public TypeMoster type;
      /*  public void Draw(Graphics g)
        {
            
        }*/

    }
    public class TypeMoster 
    {
        public String name;
        public Bitmap texture;
        public Color color;
        /*public void Draw(int x, int y)
        {
           
        }*/
        public string GetKeyTypeMonster()
        {
            List<string> key = new List<string>();
            key.Add(name);
            key.Add(color.ToString());
            return string.Join("_", key);
        }
    }
}
