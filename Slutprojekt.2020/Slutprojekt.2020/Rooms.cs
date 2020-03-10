using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt._2020
{
    class Rooms
    {
        private float treasureChance;

        private float maxTreasureChance = 1.0f;

        private int amountOfFights;

        private int maxAmountOfFights = 5;

        private List<string> roomNameList = new List<string>() { "Jail", "Kitchen", "Attic", "Basement", "Vault", "Throne room", "Laboratory", "" };

        private string roomName;

        private static Random generator = new Random();

        public Rooms()
        {
            roomName = roomNameList[generator.Next(1, roomNameList.Count())];

            treasureChance = (float) generator.NextDouble() * maxTreasureChance;

            amountOfFights = generator.Next(1, maxAmountOfFights);
        }

        public void EnterRoom()
        {
            Console.WriteLine("You enter: The " + roomName);
        }

    }
}
