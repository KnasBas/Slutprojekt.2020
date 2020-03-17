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
            strength = generator.Next(5, 11); //1 till 10 chans på alla parameterar
            Console.WriteLine("Adventurer you start with " + strength + " strength points");
            Console.ReadKey();
            intelligence = generator.Next(5, 11);
            Console.WriteLine("Adventurer you start with " + intelligence + " intelligence");
            Console.ReadKey();
            hp = generator.Next(100, maxHp);
            Console.WriteLine("Adventurer you start with " + hp + " healthpoints");
            Console.ReadKey();
            Console.WriteLine("...");
        }
    }
}
