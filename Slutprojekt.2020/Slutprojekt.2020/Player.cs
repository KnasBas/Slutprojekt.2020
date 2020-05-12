using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Player : NPC
    {
        private int winCondition = 0; //variabeln används för att checka spelarens vinst eller förlust
        private int winterms = 0;
        private int wintemp = 0;

        public Player() //I konstruktorn ändras dictionary variabler från klassen character via en generator 
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

        public void Introduction()
        {
            Console.WriteLine("Now state your name Adventurer");
            Console.Write("[Input name]: ");
            string answer = Console.ReadLine();
            name = answer; //anropar name från Player klassen
            Console.WriteLine(name + ", I wish you the best of luck on your journey.");

            Console.WriteLine("Now, choose how many dungeon rooms you wish to explore.");
            Console.WriteLine("But remeber that you enter them in turn, [1 - x]");
            Console.Write("Input your choice: ");
        }

        public int GetPlayerWinCondition()
        {
            return winCondition;
        }

        public void SetPlayerWinCondition(int value)
        {
            winCondition = value;
        }

        public void SetPlayerWinTemp(int value)
        {
            wintemp = value;
        }

        public void SetPlayerWinTerms(int value)
        {
            winterms = winterms + value;
        }

        public bool isGameOver(bool value)
        {
            if(winCondition == 1 && value)
            {
                Console.WriteLine("You won the game!");
                return true;
            }
            else if (winCondition == 2 && value)
            {
                Console.WriteLine("You died!");
                Console.WriteLine("You lost the game");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
