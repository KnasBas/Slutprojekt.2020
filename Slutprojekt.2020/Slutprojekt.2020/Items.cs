using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Items //Item system
    {
        //Försöker bygga upp ett item sytem via ID samt behålla dess stats/syfte    
        private int hpPotions = 0;

        static Random generator = new Random();
        List<string> itemListTotal = new List<string>() { "Sword", "Headband" , "Leatherboots", "Staff", "Belt"};
        List<string> playerItems = new List<string>() { };
        Dictionary<string, int> itemStats = new Dictionary<string, int>() { };

        public void GetItem()
        {
            for (int i = 0; i < itemListTotal.Count; i++)
            {
                playerItems.Add(itemListTotal[i]);
            }
            for (int i = 0; i < playerItems.Count; i++)
            {
                itemStats.Add(playerItems[i], generator.Next(1, 11));
            }
        }

        public void GetItemStats()
        {
            if(playerItems.Count == 0)
            {
                Console.WriteLine("You do not own any items");
            }
            else
            {
                Console.WriteLine("Here is all the items you own.");
                for (int i = 0; i < playerItems.Count; i++)
                {
                    
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
                        item--;
                        Console.WriteLine(playerItems[item]);      
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input, try again");
                        Console.ReadKey();
                    }
                }

                Console.WriteLine();
            }
        }

        public int GetAmountOfPotions()
        {
            if(hpPotions == 0)
            {
                Console.WriteLine("You do not own any hp potions.");
            }

            return hpPotions;
        }

        public int BuyHpPotion()
        {
            int success = 0;

            if(hpPotions > 0)
            {
                success = 1;
                Console.WriteLine("You have " + hpPotions + " hp potions, do you wish to use one?");
                Console.WriteLine("Remember that it can only heal 35 points and that it can not excede an hp amount of 150.");
                Console.Write("yes(1)/no(2)");
                string answer = Console.ReadLine();
                int choice = 0;
                bool result = int.TryParse(answer, out choice);
                while (!result || choice > 2 && choice < 1)
                {
                    Console.WriteLine("Try again");
                    answer = Console.ReadLine();
                    result = int.TryParse(answer, out choice);
                }
                if(choice == 1)
                {
                    hpPotions--;
                }
            }
            else
            {
                Console.WriteLine("You do not own any hp potions.");
            }

            return success;
        }


        public void GetItemSword()
        {
            playerItems.Add("Sword");
        }

        public void GetRandomItem()
        {
            int temp = generator.Next(itemListTotal.Count);
            Console.WriteLine("You got: " + itemListTotal[temp] + " as your item.");
            playerItems.Add(itemListTotal[temp]);
           
        }
    }
}
