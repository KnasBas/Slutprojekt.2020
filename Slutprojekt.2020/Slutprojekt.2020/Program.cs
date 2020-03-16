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
            Player p1 = new Player();
            Items i1 = new Items();
            int winCondition = 0;

            Console.WriteLine("Now state your name Adventurer");
            Console.Write("[Input name]: ");
            string answer = Console.ReadLine();
            p1.name = answer;
            Console.WriteLine(p1.name + ", I wish you the best of luck on your journey.");

            Random generator = new Random();

            int amount = generator.Next(2, 11);

            List<Rooms> r1List = new List<Rooms>(amount);

            for (int i = 0; i < amount + 1; i++)
            {
                r1List.Add(new Rooms());
            }

            Console.WriteLine("Now, confirm which room of the dungeon you whish to start with, [1 - " + amount + "]");

            while(winCondition == 0)
            {
                Console.Write("[Input choice]: ");
                int room = CheckRoom();
                int anyFight = r1List[room].EnterRoom();
                if (anyFight == 1)
                {
                    Enemy e1 = new Enemy();
                    Console.WriteLine("Unfortunately you encounter a enemy who's ready to fight " + e1.name);

                }
                else
                {
                    if (r1List[room].InitialLoot == 10)
                    {
                        i1.GetRandomItem();
                    }
                }
            }

            



            Console.ReadLine();


            RestClient client = new RestClient("https://official-joke-api.appspot.com/");

            while (1 > 0)
            {
                RestRequest request = new RestRequest("jokes/random");
                IRestResponse response = client.Get(request);
                JokeAPI RandomJoke = JsonConvert.DeserializeObject<JokeAPI>(response.Content);
                Console.WriteLine(RandomJoke.setup);
                Console.ReadKey();
                Console.WriteLine(RandomJoke.punchline);
                Console.ReadLine();
            }

        }

        static int CheckRoom()
        {
            string answer = Console.ReadLine();
            int room;
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
