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
        //Item systmet är ännu inte helt klart, det är delvis av koden som har någon funktion där spelaren kan få items men de har inte någon interaktion hos spelaren, exempelvis mer skada i en strid.
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
                for (int i = 0; i < playerItems.Count; i++) //skriver ut items
                {
                    Console.WriteLine(playerItems[i]);
                }

                int item = -1;
                while (item < 0 && item > playerItems.Count)
                {
                    try //testade lite try catch för att testa en annan felsökningsmetod.
                    {
                        Console.WriteLine("Choose which item you want to show the stats of, (1, 2, 3 ...)");
                        Console.Write("Input: ");
                        string answer = Console.ReadLine();
                        item = int.Parse(answer);
                        item--;
                        Console.WriteLine(playerItems[item]);      
                    }
                    catch //fångar ifall item är utanför playeritems då en krasch sker.
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

        public int UseHpPotion()
        {
            int success = 0;

            if(hpPotions > 0)
            {
                success = 1;//parametern success används för att skapa interaktion mellen klasser, när värdet är 1 kommer en metod öka hp på spelaren.
                Console.WriteLine("You have " + hpPotions + " hp potions, do you wish to use one?");
                Console.WriteLine("Remember that it can only heal 35 points and that it can not excede an hp amount of 150.");
                Console.Write("yes(1)/no(2)");
                string answer = Console.ReadLine();
                int choice = 0;
                bool result = int.TryParse(answer, out choice);
                while (!result || choice > 2 && choice < 1) //felsökning
                {
                    Console.WriteLine("Try again");
                    answer = Console.ReadLine();
                    result = int.TryParse(answer, out choice);
                }
                if(choice == 1) //använder en potion
                {
                    hpPotions--;
                }
                else //denna sker när spelaren väljer nej som alternativ
                {
                    success = 0;
                }
            }
            else
            {
                Console.WriteLine("You do not own any hp potions.");
            }

            return success;
        }


        public void GetItemSword() //inte helt klar
        {
            playerItems.Add("Sword");
        }

        public void GetRandomItem() //inte helt klar
        {
            int temp = generator.Next(itemListTotal.Count);
            Console.WriteLine("You got: " + itemListTotal[temp] + " as your item.");
            playerItems.Add(itemListTotal[temp]);
           
        }
    }
}
