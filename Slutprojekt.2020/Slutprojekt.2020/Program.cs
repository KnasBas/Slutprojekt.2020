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
            Items i1 = new Items();
            Player p1 = new Player();

            Console.WriteLine("Now state your name Adventurer");
            Console.Write("[Input name]: ");
            string answer = Console.ReadLine();
            p1.name = answer;
            Console.WriteLine(p1.name + ", I wish you the best of luck on your journey.");

            Rooms r1 = new Rooms();
           
            Random generator = new Random();

            int amount = generator.Next(1, 5);

            List<Rooms> r1List = new List<Rooms>(amount);

            Console.WriteLine("Now, confirm which room of the dungeon you whish to start with, [1 - 5]");
            answer = Console.ReadLine();
            int room;
            bool resultOfAnswer = int.TryParse(answer, out room);
            while (!resultOfAnswer || room > 5 && room < 1)
            {
                Console.WriteLine("Wrong answer, try again");
                answer = Console.ReadLine();
                resultOfAnswer = int.TryParse(answer, out room);
            }

            r1.EnterRoom();

            i1.GetItemStats();






            Console.ReadLine();

            RestClient client = new RestClient("https://official-joke-api.appspot.com/");

            while(1 > 0) 
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
    }
}
