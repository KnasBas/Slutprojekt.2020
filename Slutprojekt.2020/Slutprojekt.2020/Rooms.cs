using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Rooms
    {
        private List<string> roomNameList = new List<string>() { "Jail", "Kitchen", "Attic", "Basement", "Vault", "Throne room", "Laboratory"};
        //En lista på de olika rummen som kan slumpas fram.
        private string roomName;
        private int npcOccurance = 0; //en parameter för att en npc ska möta spelaren
        private int initialLootChance;
                                         //Loot systemet är fortfarande work in progress, kommer att utvecklas vid komplettering
        public int InitialLoot 
        {
            get
            {
                return initialLootChance;
            }

            set
            {

            }
        }

        private static Random generator = new Random();

        public Rooms()
        {
            initialLootChance = generator.Next(1, 11); //1 - 10 Chans //som sagt fugnerar fortfarande inte
            roomName = roomNameList[generator.Next(1, roomNameList.Count())]; //generar ett namn för rummet
            npcOccurance = generator.Next(1, 11); // 1 - 10
            //npcOccurance = 10;
        }

        public int DoesFightOccur(int value, Items i1, Character npc1, Player p1)
        {
            int doesFightOccur = value;
            if (doesFightOccur == 0)
            {
                i1.GetItem(); //fungerar delvis
                i1.GetItemStats(); //fungerar delvis 
            }
            if (doesFightOccur == 10)
            {
                int temp = npc1.PerformJoke();
                if (temp == 1)
                {
                    GetJoke();
                    p1.SetPlayerWinTerms(1);
                }
                else
                {
                    Console.WriteLine("You decide to leave the person alone and proceed you journey");
                    p1.SetPlayerWinTerms(1);
                }
            }
            return doesFightOccur;
        }

        public void GetJoke()
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

        public int CheckRoom()
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

        public int EnterRoom(Player p1)
        {
            Console.WriteLine("You enter: The " + roomName);
            if(npcOccurance == 10) // 1/10 chans att en "npc" möter spelaren
            {
                return npcOccurance;
            }
            else
            {
                return 1;  // detta värde används i Main för att rulla en 50% risk att spelaren hamnar i en strid.
            }                          
        }
    }
}
