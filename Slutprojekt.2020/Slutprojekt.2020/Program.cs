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
            p1.Introduction();
            Rooms testroom = new Rooms();
            int amount = testroom.CheckRoom(); //skapar ett testrum för att kunna köra checkroom innan en kö skapas
            p1.SetPlayerWinTemp(amount);
            Queue<Rooms> r1Queue = new Queue<Rooms>(); //Skapar en queue av alla rum i ordning som spelaren måste ta sig an. 
            for (int i = 0; i < amount + 1; i++) //skapar x antal rum utifrån generatorn i detta fall
            {
                r1Queue.Enqueue(new Rooms()); //Här skapas det antal rum spelaren valde
            }
            while (p1.GetPlayerWinCondition() == 0) //en while loop som håller igång spelet tills att spelaren har klarat av spelet värdet ändras.
            {
                if(r1Queue.Count != 0)
                {
                    int fight = r1Queue.Dequeue().DoesFightOccur(r1Queue.Dequeue().EnterRoom(p1), i1, npc1, p1); //parametern tar upp värde från metoden enterrooms som slumpar ett värde 0 eller 1      
                    if (fight == 1)
                    {
                        Enemy e1 = new Enemy();
                        Fight f1 = new Fight();
                        f1.GetStats(p1.ReturnStats()); //ett system för att överföra spelarens stats till fight klassen.
                        f1.StartFight(p1, e1, i1); //en metod från fight klassen utspelas och värdet utifrån olika utfall ger vinst eller förlust.           
                    }
                }  
                Console.WriteLine("Next room");
            }
            if(!r1Queue.Any())
            {
                p1.isGameOver(true);
                Console.ReadKey();
            }            
            Console.ReadLine();
        }
    }
}
