using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Fight
    {
        private Dictionary<string, int> PlayerStats = new Dictionary<string, int>();
        private Dictionary<string, int> Enemystats = new Dictionary<string, int>();


        public Fight()
        {
            PlayerStats.Add("Hp", 100); //Här konstateras bas värden för en karaktär.
            PlayerStats.Add("Strength", 0);
            PlayerStats.Add("Intelligence", 0);

            Enemystats.Add("Hp", 100); //Här konstateras bas värden för en karaktär.
            Enemystats.Add("Strength", 0);
            Enemystats.Add("Intelligence", 0);
        }

        public Dictionary<string, int> GetStats(Dictionary<string, int> value1)
        {
            PlayerStats = value1;
            return value1;
        }

        public int StartFight(Player p1, Enemy e1, Items i1)
        {
            Console.WriteLine("Unfortunately you encounter a enemy who's ready to fight, [" + e1.name + "]");

            p1.TransferStats(PlayerStats);

            while (e1.HP > 0 && p1.HP > 0) //striden fortsätter tills att någon stupar
            {        
                int turncounter = 0; //en parameter som visar hur många rundor som pågått under striden
                turncounter++;
                Console.WriteLine("Input your approach for the current turn. [turn: " + turncounter + "]");
                int action = p1.GetCharacterAttackStyle();

                while (action == 3 && i1.GetAmountOfPotions() == 0)
                {
                    action = p1.GetCharacterAttackStyle();
                }
                //här finns olika utfall beroende på vilket alternativ spelaren väljer, 3 till exempel tar spelaren till hens potions
                if (action == 3 && i1.GetAmountOfPotions() > 0)
                {
                    p1.IncreaseHealth(i1.UseHpPotion());
                }

                e1.Hurt(p1.GetCharacterDamage(action), action); //enemyn använder player klassens metoder för att bestämma hur mycket skada den tar.
                Console.WriteLine("Press any key to proceed");
                Console.ReadKey();
               
                if (e1.HP > 0) //eftersom jag inte vill att striden ska fortsätta när fienden egentligen har dött så har jag en enkel if-sats för att enbart låta fienden attakera spelaren när den har hp över 0
                {
                    action = e1.GetCharacterAttackStyle();
                    p1.Hurt(e1.GetCharacterDamage(action), action); // som tidigare fast att playern använder fiendens attack metod för att bestämma skadan
                    
                    Console.WriteLine("Press any key to proceed");
                    Console.ReadKey();
                    Console.WriteLine("Do you wish to see the current stats of each fighter before next the following turn?");
                    Console.WriteLine("yes(1)/no(2)");
                    string answer = Console.ReadLine();
                    int temp = 0;
                    bool showStats = int.TryParse(answer, out temp);
                    while (!showStats || temp != 1 && temp != 2) //felsökning
                    {
                        Console.WriteLine("Wrong input!");
                        answer = Console.ReadLine();
                        showStats = int.TryParse(answer, out temp);
                    }
                    if (temp == 1) //ifall spelaren väljer yes kommer hen att kunna se alla stats, både fiende och spelare.
                    {
                        p1.GetCharacterStats();
                        e1.GetCharacterStats();
                        Console.WriteLine("Press any key to proceed");
                        Console.ReadKey();
                    }
                }
            }

            int temporary = 0;

            if (e1.HP <= 0)
            {
                Console.WriteLine("You won the battle.");
                temporary = 1;
            }
            else //enkla arguemnt om vem som vann striden
            {
                Console.WriteLine("You died!");
                temporary = 2; //du dog och spelet avslutas
            }

            return temporary;
        }
    }
}
