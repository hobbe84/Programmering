using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer_A
{
    class Program
    {
        //Metoden CreateSolid visar en header som talar om vilken 
        //typ av figur vi har valt att skapa och läser in radien och höjden.
        //När värdena är inmatade skapas ett nytt objekt.
        static Solid CreateSolid(SolidType solidType)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔═════════════════════════════════════╗");

            switch (solidType)
            {
                case SolidType.CircularCone:
                    Console.WriteLine("║                 Kon                 ║");
                    break;
                case SolidType.Cylinder:
                    Console.WriteLine("║              Cylinder               ║");
                    break;
            }
            Console.WriteLine("╚═════════════════════════════════════╝");

            double radius = ReadDoubleGreaterThenZero("\nAnge radien (r): ");
            double height = ReadDoubleGreaterThenZero("\nAnge höjden (h): ");

            if (solidType == SolidType.Cylinder)
            {
                return new Cylinder(radius, height);
            }
            else
            {
                return new CircularCone(radius, height);
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Solida Volymer Nivå A";
            do
            {
                Console.Clear();
                Console.CursorVisible = true;
                ViewMenu();
                switch (Console.ReadLine()) // Smart funktion som tar strängen via ReadLine() och skickar respektive val till metoden CreateSolid()
                {
                    case "0": return;

                    case "1": ViewSolidDetail(CreateSolid(SolidType.CircularCone));
                        break;
                    case "2": ViewSolidDetail(CreateSolid(SolidType.Cylinder));
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nInte ett giltigt menyval!");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck valfri tangent för att börja om - ESC avslutar.");
                Console.ResetColor();
                Console.CursorVisible = false;
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        //Metoden ReadDoubleGreaterThanZero kontrollerar att värdet för radien/höjden
        //är större än noll. Om inte visas ett felmeddelande och man får en ny chans.
        static double ReadDoubleGreaterThenZero(string prompt)
        {
            double input;
            do
            {
                Console.ResetColor();
                Console.Write(prompt);

                if (double.TryParse(Console.ReadLine(), out input) && input > 0)
                {
                    return input;
                }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nFEL! Måste vara ett värde större än 0.");
                Console.ResetColor();
            } while (true);
        }
        //Metod som skriver programmets huvudmeny.
        static void ViewMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║           Solida volymer            ║");
            Console.WriteLine("║              Av: Jocke              ║");
            Console.WriteLine("╚═════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("0. Avsluta\n");
            Console.WriteLine("1. Kon\n");
            Console.WriteLine("2. Cylinder");
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════");
            Console.Write("Ange ditt menyval [0-2]: ");
        }
        //Visar detaljheader och hämtar värden via ToString i Klassen Solid.
        static void ViewSolidDetail(Solid solid)
        {            
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║              Detaljer               ║");
            Console.WriteLine("╚═════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write(solid.ToString());
            Console.WriteLine("\n═══════════════════════════════════════");

        }
    }
}
