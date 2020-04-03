using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
namespace Slutprojekt._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player(); //två klasser som skapas tidigt för att köra deras konstruktorer samt tillgänglighet. 
            Items i1 = new Items();
            NPC npc1 = new NPC();
            int winCondition = 0; //variabeln används för att checka spelarens vinst eller förlust

            Console.WriteLine("Now state your name Adventurer");
            Console.Write("[Input name]: ");
            string answer = Console.ReadLine();
            p1.name = answer; //anropar name från Player klassen
            Console.WriteLine(p1.name + ", I wish you the best of luck on your journey.");

            Console.WriteLine("Now, choose how many dungeon rooms you wish to explore.");
            Console.WriteLine("But remeber that you enter them in turn, [1 - x]");
            Console.Write("Input your choice: ");

            string amountString = Console.ReadLine();
            int amount;
            bool roomCheck = int.TryParse(amountString, out amount);

            while(!roomCheck || amount<= 1) //En enkel felsökningsmetod
            {
                Console.WriteLine("Invalid input, try again");
                Console.Write("Input your choice:");
                amountString = Console.ReadLine();
                roomCheck = int.TryParse(amountString, out amount);
            }

            //List<Rooms> r1List = new List<Rooms>(amount);
            Queue<Rooms> r1Queue = new Queue<Rooms>(); //Skapar en queue av alla rum i ordning som spelaren måste ta sig an. 

            for (int i = 0; i < amount + 1; i++) //skapar x antal rum utifrån generatorn i detta fall
            {
                r1Queue.Enqueue(new Rooms()); //Här skapas det antal rum spelaren valde
            }    

            while (winCondition == 0) //en while loop som håller igång spelet tills att spelaren har klarat av spelet värdet ändras.
            {
                //int room = CheckRoom(amount);
                //amount = amount - 1;
                if (amount <= 0)
                {
                    amount = 0;
                    winCondition = 1;
                }
                int doesFightOccur = r1Queue.Dequeue().EnterRoom(); //parametern tar upp värde från metoden enterrooms som slumpar ett värde 0 eller 1
                //doesFightOccur = 0;
                if (doesFightOccur == 0)
                {
                    i1.GetItem(); //fungerar delvis
                    i1.GetItemStats(); //fungerar delvis 
                }
                if(doesFightOccur == 10)
                {
                    int temp = npc1.PerformJoke();
                    if (temp == 1)
                    {
                        GetJoke();
                    }
                    else
                    {
                        Console.WriteLine("You decide to leave the person alone and proceed you journey");
                    }
                }
                if (doesFightOccur == 1)
                {
                    Enemy e1 = new Enemy(); //enemy klass
                    Console.WriteLine("Unfortunately you encounter a enemy who's ready to fight, [" + e1.name + "]");
                    int turncounter = 0; //en parameter som visar hur många rundor som pågått under striden
                    while (e1.HP > 0 && p1.HP > 0) //striden fortsätter tills att någon stupar
                    {
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
                            answer = Console.ReadLine();
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
                                p1.GetCharacterStas();
                                e1.GetCharacterStas();
                                Console.WriteLine("Press any key to proceed");
                                Console.ReadKey();
                            }
                        }
                    }
                    if (e1.HP <= 0)
                    {
                        Console.WriteLine("You won the battle.");
                    }
                    else //enkla arguemnt om vem som vann striden
                    {
                        Console.WriteLine("You died!");
                        winCondition = 2; //du dog och spelet avslutas
                    }
                }
                /*else //denna har inte en ful använding ännu eftersom item systemet krånglar, men annars fungerande kod
                {
                    i1.GetRandomItem();
                    Console.WriteLine("Do you wish to view the item, yes(1) no(2)");
                    answer = Console.ReadLine();
                    int choice = 0;
                    bool result = int.TryParse(answer, out choice);
                    while (!result || choice > 2 && choice < 1)
                    {
                        Console.WriteLine("Try again");
                        answer = Console.ReadLine();
                        result = int.TryParse(answer, out choice);
                    }
                    if (choice == 1)
                    {
                        i1.GetItemStats();
                    }
                }*/

                if (winCondition == 1)
                {
                    Console.WriteLine("You won the game!");
                }
                else if (winCondition == 2)
                {
                    Console.WriteLine("You lost the game");
                }

                Console.WriteLine("Next room");
            }
            if(r1Queue.Count == 0)
            {
                Console.WriteLine("You won the game!");
                
                winCondition = 1; //spelaren klarade alla rum och vann spelet

                Console.ReadKey();
            }
            
            Console.ReadLine();
        }

        static void GetJoke()
        {
            RestClient client = new RestClient("https://official-joke-api.appspot.com/");
            RestRequest request = new RestRequest("jokes/random");
            IRestResponse response = client.Get(request);
            JokeAPI RandomJoke = JsonConvert.DeserializeObject<JokeAPI>(response.Content);
            Console.WriteLine(RandomJoke.setup);
            Console.ReadKey();
            Console.WriteLine(RandomJoke.punchline);
            Console.ReadKey();

        }

        /*static int CheckRoom(int amount) //Den här koden fungerar fortfarande men det har inte något syfte längre eftersom jag valde att byta min list till en queue istället, ville dock inte radera den.
        {
            Console.WriteLine("[1 - " + amount + "]");
            Console.Write("[Input choice]: ");
            string answer = Console.ReadLine();
            int room = 0;
            bool resultOfAnswer = int.TryParse(answer, out room);
            while (!resultOfAnswer || room > 5 && room < 1) //felsökningsmetod
            {
                Console.WriteLine("Wrong answer, try again");
                answer = Console.ReadLine();
                resultOfAnswer = int.TryParse(answer, out room);
            }

            return room;
        }*/
    }
}
