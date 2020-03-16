using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Rooms
    {
        private List<string> roomNameList = new List<string>() { "Jail", "Kitchen", "Attic", "Basement", "Vault", "Throne room", "Laboratory", "" };

        private string roomName;

        private int initialLootChance;

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
            initialLootChance = generator.Next(1, 11); //1 - 10 Chans
            roomName = roomNameList[generator.Next(1, roomNameList.Count())];
        }

        public int EnterRoom()
        {
            Console.WriteLine("You enter: The " + roomName);
            return generator.Next(2);
        }

        public int 

    }
}
