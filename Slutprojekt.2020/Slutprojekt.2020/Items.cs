using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Items //Item system
    {
        private (int, string, int, bool) Sword = (1, "Bonus Strength", 10, false); //Försöker bygga upp ett item sytem via ID samt behålla dess stats/syfte
        private (int, string, int, bool) Headband = (2, "Bonus Intelligence", 10, false);

        static Random generator = new Random();

        List<string> itemListTotal = new List<string>() { "Sword", "Headband" };
        List<string> playerItems = new List<string>() { };

        public void GetItemStats()
        {
            if(playerItems.Count == 0)
            {
                Console.WriteLine("You do not own any items");
            }
            else
            {
                Console.WriteLine("Here is all the itms you own.");
                for (int i = 0; i < playerItems.Count; i++)
                {
                    Console.WriteLine(playerItems[i]);
                }

                int item = -1;
                while (item < 0 && item > playerItems.Count)
                {
                    try
                    {
                        Console.WriteLine("Choose which item you want to show the stats of, (1, 2, 3 ...)");
                        Console.Write("Input: ");
                        string answer = Console.ReadLine();
                        item = int.Parse(answer);
                        item = item - 1;
                        Console.WriteLine(playerItems[item]);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input, try again");
                        Console.ReadKey();
                    }
                }

                Console.WriteLine(Sword);
            }

            


        }

        public void GetItemSword()
        {
            playerItems.Add("Sword");
            Sword = (1, "Bonus Strength", generator.Next(1, 11), true);
        }

        public void GetRandomItem()
        {
            int temp = generator.Next(1, (itemListTotal.Count));
            Console.WriteLine("You got: " + itemListTotal[temp] + " as your item.");
            playerItems.Add(itemListTotal[temp]);
            Sword = (1, "Bonus Strength", generator.Next(1, 11), true);
        }
    }
}
