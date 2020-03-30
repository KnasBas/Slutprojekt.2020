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

        protected Dictionary<string, int> CharacterStats = new Dictionary<string, int>();     

        protected int maxHp = 150;

        protected static Random generator = new Random();

        /*protected int strength;

        protected int intelligence;*/

        //protected int hp;

        public Character()
        {
            CharacterStats.Add("Hp", 100); //Här konstateras bas värden för en karaktär.
            CharacterStats.Add("Strength", 0);
            CharacterStats.Add("Intelligence", 0);
        }

        public int HP 
        { 
            get 
            {
                return CharacterStats["Hp"];
            }
            set { }
        }

        public void GetCharacterStas()
        {
            Console.WriteLine("Fighter: " + name);
            Console.WriteLine("HP [" + CharacterStats["Hp"] + "]");
            Console.WriteLine("Strength [" + CharacterStats["Strength"] + "]");
            Console.WriteLine("Intelligence [" + CharacterStats["Intelligence"] + "]");       
        }

        public virtual int GetCharacterAttackStyle()
        {
            Console.WriteLine("{Offense [1]}/ {Defence [2]}/ {HealthPotion [3]}");
            string input = Console.ReadLine();
            int temp = 0;
            bool result = int.TryParse(input, out temp);
            while(!result || temp != 1 && temp != 2 && temp != 3)
            {
                Console.WriteLine("Wrong input!");
                input = Console.ReadLine();
                result = int.TryParse(input, out temp);
            }

            return temp;
        }

        public int GetCharacterDamage(int amount)
        {
            int criticalChance;

            int temp = generator.Next(1, 10);

            criticalChance = temp + CharacterStats["Intelligence"];

            if (criticalChance >= 15)
            {
                Console.WriteLine("This turn " + name + " were smart enough to get a critical hit!");
            }
            int dmg = 0;
            switch (amount)
            {
                case 1: //Offense
                    if (criticalChance >= 15)
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

        public int IncreaseHealth(int amount)
        {
            if(amount == 1)
            {
                CharacterStats["Hp"] = CharacterStats["Hp"] + 30;
                if(CharacterStats["Hp"] > maxHp)
                {
                    CharacterStats["Hp"] = maxHp;
                }
                Console.WriteLine("You heal for 30 points of hp, you have now " + CharacterStats["Hp"] + "hp");
            }
            return CharacterStats["Hp"];
        }

        public int Hurt(int amount)
        {
            CharacterStats["Hp"] = CharacterStats["Hp"] - amount;
            if(CharacterStats["Hp"] <= 0)
            {
                CharacterStats["Hp"] = 0;
            }
            Console.WriteLine(name + " takes damage and now has " + CharacterStats["Hp"] + "hp left");
            return CharacterStats["Hp"];
        }
    }
}
