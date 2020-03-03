﻿using System;
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
            RestClient client = new RestClient("https://official-joke-api.appspot.com/");

            RestRequest request = new RestRequest("jokes/random");

            IRestResponse response = client.Get(request);

            JokeAPI TestJoke = JsonConvert.DeserializeObject<JokeAPI>(response.Content);

            for (int i = 0; i < TestJoke.Joke.Count; i++)
            {
                Console.WriteLine(TestJoke.Joke[i]);
            }

         

            Console.ReadLine();
        }
    }
}
