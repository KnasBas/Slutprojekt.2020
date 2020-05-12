using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class NPC : Character
    {
        private List<string> npcNames = new List<string>() { "George", "Harry", "Edward" };
        private string npcname = "";
        public NPC()
        {
            npcname = npcNames[generator.Next(npcNames.Count)];
        }

        public override int PerformJoke() //En metod som används när en parameter från room klassen har ett specifikt värde triggas denna metod i main.
        {
            Console.WriteLine("You see a person in the room, you try to approach the person.");
            Console.ReadKey();
            Console.WriteLine("Hello adventurer, would you like to hear a joke perhaps?");
            Console.Write("Yes(1)/No(2): ");
            string answer = Console.ReadLine();
            int temp = 0;
            bool isJoke = int.TryParse(answer, out temp);
            while (!isJoke || temp != 1 && temp != 2) //felsökning
            {
                Console.WriteLine("Wrong input!");
                answer = Console.ReadLine();
                isJoke = int.TryParse(answer, out temp);
            }

            return temp;
        }
    }
}

                
    

