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

            while(!roomCheck || amount<= 1)
            {
                Console.WriteLine("Invalid input, try again");
                Console.Write("Input your choice:");
                amountString = Console.ReadLine();
                roomCheck = int.TryParse(amountString, out amount);
            }

            //List<Rooms> r1List = new List<Rooms>(amount);
            Queue<Rooms> r1Queue = new Queue<Rooms>();

            for (int i = 0; i < amount + 1; i++) //skapar x antal rum utifrån generatorn i detta fall
            {
                r1Queue.Enqueue(new Rooms());
            }    

            while (winCondition == 0)
            {
                //int room = CheckRoom(amount);
                //amount = amount - 1;
                if (amount <= 0)
                {
                    amount = 0;
                    winCondition = 1;
                }
                int doesFightOccur = r1Queue.Dequeue().EnterRoom();
                //doesFightOccur = 0;
                if (doesFightOccur == 0)
                {
                    i1.GetItem();
                    i1.GetItemStats();
                }
                if (doesFightOccur == 1)
                {
                    Enemy e1 = new Enemy();
                    Console.WriteLine("Unfortunately you encounter a enemy who's ready to fight, [" + e1.name + "]");
                    int turncounter = 0;
                    while (e1.HP > 0 && p1.HP > 0)
                    {
                        turncounter++;
                        Console.WriteLine("Input your approach for the current turn. [turn: " + turncounter + "]");
                        int action = p1.GetCharacterAttackStyle();

                        while (action == 3 && i1.GetAmountOfPotions() == 0)
                        {
                            action = p1.GetCharacterAttackStyle();
                        }

                        if (action == 3 && i1.GetAmountOfPotions() > 0)
                        {
                            p1.IncreaseHealth(i1.BuyHpPotion());
                        }

                        e1.Hurt(p1.GetCharacterDamage(action));
                        Console.WriteLine("Press any key to proceed");
                        Console.ReadKey();

                        if (e1.HP > 0)
                        {
                            action = e1.GetCharacterAttackStyle();
                            p1.Hurt(e1.GetCharacterDamage(action));

                            Console.WriteLine("Press any key to proceed");
                            Console.ReadKey();
                            Console.WriteLine("Do you wish to see the current stats of each fighter before next the following turn?");
                            Console.WriteLine("yes(1)/no(2)");
                            answer = Console.ReadLine();
                            int temp = 0;
                            bool showStats = int.TryParse(answer, out temp);
                            while (!showStats || temp != 1 && temp != 2)
                            {
                                Console.WriteLine("Wrong input!");
                                answer = Console.ReadLine();
                                showStats = int.TryParse(answer, out temp);
                            }
                            if (temp == 1)
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
                    else
                    {
                        Console.WriteLine("You died!");
                        winCondition = 2;
                    }
                }

                else
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
                }

                if (winCondition == 1)
                {
                    Console.WriteLine("You won the game!");
                }
                else if (winCondition == 2)
                {
                    Console.WriteLine("You lost the game");
                }

            }

            GetJoke();

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
            Console.ReadLine();

        }

        static int CheckRoom(int amount)
        {
            Console.WriteLine("[1 - " + amount + "]");
            Console.Write("[Input choice]: ");
            string answer = Console.ReadLine();
            int room = 0;
            bool resultOfAnswer = int.TryParse(answer, out room);
            while (!resultOfAnswer || room > 5 && room < 1)
            {
                Console.WriteLine("Wrong answer, try again");
                answer = Console.ReadLine();
                resultOfAnswer = int.TryParse(answer, out room);
            }

            return room;
        }
    }
}
