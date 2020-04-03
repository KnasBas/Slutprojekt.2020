using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
        

        public int EnterRoom()
        {
            Console.WriteLine("You enter: The " + roomName);
            if(npcOccurance == 10) // 1/10 chans att en "npc" möter spelaren
            {
                return npcOccurance;
            }
            else
            {
                return generator.Next(2);  // detta värde används i Main för att rulla en 50% risk att spelaren hamnar i en strid.
            }                          
        }
    }
}
