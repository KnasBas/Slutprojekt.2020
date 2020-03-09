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

            Rooms r1 = new Rooms();
           
            Random generator = new Random();

            int amount = generator.Next(1, 5);

            List<Rooms> r1List = new List<Rooms>(amount);











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
