using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Character
    {
        public string name;

        protected int strength;

        protected int intelligence;

        protected int hp;

        protected int maxHp = 150;

        protected static Random generator = new Random();

        public void GetCharacterStas()
        {
            Console.WriteLine(name);
            Console.WriteLine(strength);
            Console.WriteLine(intelligence);
            Console.WriteLine(hp);
        }

        public int Damage()
        {
            float temp = strength;

            //float dmg = (float) generator.NextDouble() * temp *1.5f;

            int dmg  = generator.Next(strength, strength + 5);

            return dmg;
        }

        public int Hurt(int amount)
        {
            hp = hp - amount;
            return hp;
        }
    }
}
