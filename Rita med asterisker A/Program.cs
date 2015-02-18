using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rita_med_asterisker_A
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Loopar varje rad 25 gånger
            for (int rad = 0; rad < 25; rad++)
            {
                if (rad % 2 == 1) // Lägger mellanrummet på varannan rad, jämnt radnummer
                {
                    Console.Write(" ");
                }
                switch (rad % 3) // kör igenom switchsatsen cases för varje loop, startar sen om på case 0 
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }
                // 
                for (int col = 0; col < 39; col++) // Ritar 39 stjänor på varje rad
                {
                    Console.Write("* ");

                }
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.WriteLine("Tryck valfri tangent för att avsluta...");
            Console.ReadKey(); // Väntar på KeyInput innan programmet avslutas 
        }
    }
}
