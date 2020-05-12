using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Character
    {
        public string name; //namn

        protected Dictionary<string, int> CharacterStats = new Dictionary<string, int>();    //Jag använder en dictionary eftersom den kan använda en string som index men innehåller int värden, mycket praktisk för att hålla int parameterar på ett ställe. 

        protected int maxHp = 150;

        protected static Random generator = new Random(); //generator

        public Character()
        {
            CharacterStats.Add("Hp", 100); //Här konstateras bas värden för en karaktär.
            CharacterStats.Add("Strength", 1);
            CharacterStats.Add("Intelligence", 1);
        }

        public int HP 
        { 
            get 
            {
                return CharacterStats["Hp"]; //returnerar karaktärens nuvarande hp.
            }
            set { } //behöver ingen set
        }

        public void TransferStats(Dictionary<string, int> value)
        {
            CharacterStats = value;
        }

        public void GetCharacterStats() //skriver ut stats
        {
            Console.WriteLine("Fighter: " + name);
            Console.WriteLine("HP [" + CharacterStats["Hp"] + "]");
            Console.WriteLine("Strength [" + CharacterStats["Strength"] + "]");
            Console.WriteLine("Intelligence [" + CharacterStats["Intelligence"] + "]");       
        }

        public Dictionary<string, int> ReturnStats()
        {
            return CharacterStats;
        }

        public virtual int GetCharacterAttackStyle() //här är en metod för att hämta en input från spelaren om vilken attackstil hen vill ha under den rundan av striden.
        {
            Console.WriteLine("{Offense [1]}/ {Defence [2]}/ {HealthPotion [3]}"); //alternativ
            string input = Console.ReadLine();
            int temp = 0; //temporär parameter
            bool result = int.TryParse(input, out temp);
            while(!result || temp != 1 && temp != 2 && temp != 3) //felsökning
            {
                Console.WriteLine("Wrong input!");
                input = Console.ReadLine(); //tillåter spelaren att inte göra fel och behöver därför skriva in ett giltigt alternativ.
                result = int.TryParse(input, out temp); 
            }
            return temp;
        }

        public int GetCharacterDamage(int amount) //hämtar ett värde från main, (attackstil)
        {
            int criticalChance;

            int temp = generator.Next(1, 10);                //en int temp används för att skapa ett chans system med att karaktären har en chans att gör mer skada
            criticalChance = temp + CharacterStats["Intelligence"];

            if (criticalChance >= 15)
            {
                Console.WriteLine("This turn " + name + " were smart enough to get a critical hit!");
            }
            int dmg = 0;
            switch (amount)
            {
                case 1: //Offense
                    if (criticalChance >= 15) //Case 1 och 2 innehåller två olika utfall, skillnaden är att den första är när karaktären lyckas få en critical hit.
                    {
                        dmg = generator.Next(CharacterStats["Strength"], (CharacterStats["Strength"] + 5));
                        dmg = dmg * 2;
                        Console.WriteLine(name + " does " + dmg + " points of damage.");
                    }
                    else
                    {
                        dmg = generator.Next(CharacterStats["Strength"], (CharacterStats["Strength"] + 5));
                        Console.WriteLine(name + " does " + dmg + " points of damage.");
                    }            
                    break;

                case 2: //Defence
                    if (criticalChance >= 15)
                    {
                        dmg = generator.Next(1, CharacterStats["Strength"]);
                        dmg = dmg * 2;
                        Console.WriteLine(name + " does " + dmg + " points of damage.");
                    }
                    else
                    {
                        dmg = generator.Next(1, CharacterStats["Strength"]);
                        Console.WriteLine(name + " does " + dmg + " points of damage.");
                    }
                    break;
            }

            return dmg;
        }

        public int IncreaseHealth(int amount) //metoden samarbetar med en metod från item klassen, UseHealthPotion.
        {
            if(amount == 1)
            {
                CharacterStats["Hp"] = CharacterStats["Hp"] + 30; //Ökar hp
                if(CharacterStats["Hp"] > maxHp) //får inte överskrida maxhp värdet
                {
                    CharacterStats["Hp"] = maxHp;
                }
                Console.WriteLine("You heal for 30 points of hp, you have now " + CharacterStats["Hp"] + "hp");
            }
            return CharacterStats["Hp"];
        }

        public int Hurt(int amount, int style)
        {
            if(style == 2) //när style är 2 har karaktären valt defence för rundan vilket betyder att skadan minskas.
            {
                CharacterStats["Hp"] = CharacterStats["Hp"] - (amount/2);
                if (CharacterStats["Hp"] <= 0)
                {
                    CharacterStats["Hp"] = 0; //tillåter inte hp att gå under 0
                }
                Console.WriteLine(name + " takes damage and now has " + CharacterStats["Hp"] + "hp left");
            }
            else
            {
                CharacterStats["Hp"] = CharacterStats["Hp"] - amount;
                if (CharacterStats["Hp"] <= 0)
                {
                    CharacterStats["Hp"] = 0;
                }
                Console.WriteLine(name + " takes damage and now has " + CharacterStats["Hp"] + "hp left");
            }       
            return CharacterStats["Hp"];
        }

        public virtual int PerformJoke()
        {
            return 0;
        }

    }
}
