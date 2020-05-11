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
            Character npc1 = new NPC();
            int winCondition = 0; //variabeln används för att checka spelarens vinst eller förlust
            int winterms = 0;
            int wintemp = 0;
            string answer = Introduction(p1);
            int amount = CheckRoom();

            wintemp = amount;
            //List<Rooms> r1List = new List<Rooms>(amount);
            Queue<Rooms> r1Queue = new Queue<Rooms>(); //Skapar en queue av alla rum i ordning som spelaren måste ta sig an. 

            for (int i = 0; i < amount + 1; i++) //skapar x antal rum utifrån generatorn i detta fall
            {
                r1Queue.Enqueue(new Rooms()); //Här skapas det antal rum spelaren valde
            }    

            while (winCondition == 0) //en while loop som håller igång spelet tills att spelaren har klarat av spelet värdet ändras.
            {                    
               int doesFightOccur = r1Queue.Dequeue().EnterRoom(); //parametern tar upp värde från metoden enterrooms som slumpar ett värde 0 eller 1
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
                        winterms++;
                    }
                    else
                    {
                        Console.WriteLine("You decide to leave the person alone and proceed you journey");
                        winterms++;
                    }                
                }
                if (doesFightOccur == 1)
                {
                    Enemy e1 = new Enemy();
                    Fight f1 = new Fight();
                    f1.GetStats(p1.ReturnStats());
                    int x = f1.StartFight(p1, e1, i1);
                    if (x == 1) { Console.WriteLine("You won the battle."); winterms = 1; }
                    else //enkla arguemnt om vem som vann striden
                    {
                        Console.WriteLine("You died!");
                        winCondition = 2; //du dog och spelet avslutas
                    }
                    if (winterms == wintemp){ winCondition = 1; }            
                }
                if (winCondition == 1){ Console.WriteLine("You won the game!" ); }
                else if (winCondition == 2){ Console.WriteLine("You lost the game"); }
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

        static int CheckRoom()
        {
            string amountString = Console.ReadLine();
            int amount;
            bool roomCheck = int.TryParse(amountString, out amount);
            while (!roomCheck || amount <= 1) //En enkel felsökningsmetod
            {
                Console.WriteLine("Invalid input, try again");
                Console.Write("Input your choice:");
                amountString = Console.ReadLine();
                roomCheck = int.TryParse(amountString, out amount);
            }

            return amount;
        }

        static string Introduction(Player p1)
        {
            Console.WriteLine("Now state your name Adventurer");
            Console.Write("[Input name]: ");
            string answer = Console.ReadLine();
            p1.name = answer; //anropar name från Player klassen
            Console.WriteLine(p1.name + ", I wish you the best of luck on your journey.");

            Console.WriteLine("Now, choose how many dungeon rooms you wish to explore.");
            Console.WriteLine("But remeber that you enter them in turn, [1 - x]");
            Console.Write("Input your choice: ");

            return p1.name;
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
