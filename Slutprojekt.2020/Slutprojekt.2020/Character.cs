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

        protected static Random generator = new Random();

        public int HP 
        { 
            get 
            {
                return hp;
            }
            set { }
        }

        public void GetCharacterStas()
        {
            Console.WriteLine("Fighter: " + name);
            Console.WriteLine("HP [" + hp + "]");
            Console.WriteLine("Strength [" + strength + "]");
            Console.WriteLine("Intelligence [" + intelligence + "]");       
        }

        public virtual int GetCharacterAttackStyle()
        {
            Console.WriteLine(" {Offence [1]}/ {Defence [2]}/ {Use a HealthPotion[3]}");
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
            criticalChance = temp + intelligence;
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
                        dmg = generator.Next(strength, (strength + 5));
                        dmg = dmg * 2;
                        Console.WriteLine(name + " does " + dmg + " points of damage.");
                    }
                    else
                    {
                        dmg = generator.Next(strength, (strength + 5));
                        Console.WriteLine(name + " does " + dmg + " points of damage.");
                    }            
                    break;

                case 2: //Defence
                    if (criticalChance >= 15)
                    {
                        dmg = generator.Next(1, strength);
                        dmg = dmg * 2;
                        Console.WriteLine(name + " does " + dmg + " points of damage.");
                    }
                    else
                    {
                        dmg = generator.Next(1, strength);
                        Console.WriteLine(name + " does " + dmg + " points of damage.");
                    }
                    break;
            }  
            return dmg;
        }

        public int Hurt(int amount)
        {
            hp = hp - amount;
            if(hp <= 0)
            {
                hp = 0;
            }
            Console.WriteLine(name + " takes damage and now has " + hp + "hp left");
            return hp;
        }
    }
}
