using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Enemy : Character
    {
        private List<string> enemyType = new List<string>() {"Skeleton" , "Zombie", "Ghost", "Giant" };

        private float treasureChance;

        private float maxTreasureChance = 1.0f;

        private int amountOfFights;

        private int maxAmountOfFights = 5;
       
        public Enemy()
        {
            int temp = generator.Next(1, enemyType.Count + 1);

            hp = generator.Next(100, maxHp);

            name = enemyType[temp];

            treasureChance = (float)generator.NextDouble() * maxTreasureChance;

            amountOfFights = generator.Next(1, maxAmountOfFights);

            switch (temp)
            {
                case 1: //Skeleton
                    intelligence = generator.Next(1, 3);
                    strength = generator.Next(1, 11);
                    hp = generator.Next(hp, maxHp + 1);
                    break;

                case 2: //Zombie
                    intelligence = generator.Next(1, 1);
                    strength = generator.Next(5, 15);
                    hp = generator.Next(hp, maxHp + 1);
                    break;

                case 3: //Ghost
                    intelligence = generator.Next(1, 10);
                    strength = generator.Next(1, 10);
                    hp = generator.Next(hp, maxHp + 1);
                    break;

                case 4: //Giant
                    intelligence = generator.Next(1, 5);
                    strength = generator.Next(5, 15);
                    hp = generator.Next(hp, maxHp + 1);
                    break;
            }
        }

        public override int GetCharacterAttackStyle()
        {
            List<string> attackStyleList = new List<string>() { "[Offense]", "[Defence]" };
            int temp = generator.Next(2);
            Console.WriteLine(name + " chose " + attackStyleList[temp] + " as their attackstyle.");
            return temp;
        }

        public int GetNumberOfFights()
        {
            return amountOfFights;
        }

        public bool GetLoot()
        {
            if(treasureChance >= 0.5f)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }
    }
}
