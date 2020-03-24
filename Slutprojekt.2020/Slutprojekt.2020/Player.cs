using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Player : Character
    {           
        public Player()
        {
            CharacterStats["Strength"] = generator.Next(5, 11); //1 till 10 chans på alla parameterar
            Console.WriteLine("Adventurer you start with " + CharacterStats["Strength"] + " strength points");
            Console.ReadKey();
            CharacterStats["Intelligence"] = generator.Next(5, 11);
            Console.WriteLine("Adventurer you start with " + CharacterStats["Intelligence"] + " intelligence");
            Console.ReadKey();
            CharacterStats["Hp"] = generator.Next(100, maxHp);
            Console.WriteLine("Adventurer you start with " + CharacterStats["Hp"] + " healthpoints");
            Console.ReadKey();
            Console.WriteLine("...");
        }
    }
}
