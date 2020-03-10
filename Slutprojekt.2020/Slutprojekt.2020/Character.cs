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

        public void GetCharacterStas()
        {
            Console.WriteLine(name);
            Console.WriteLine(strength);
            Console.WriteLine(intelligence);
            Console.WriteLine(hp);
        }
    }
}
