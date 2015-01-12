using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lonerevision_A
{
    class Program
    {


        static void Main(string[] args)
        {
            int antalLoner;

            do
            {
                Console.Clear();
                antalLoner = LasInt("Ange antal löner att mata in: ");

                if (antalLoner < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDu måste mata in minst tvä löner för att kunna göra en beräkning!");
                    Console.ResetColor();
                    
                }
                else
                {
                    
                    HanteraLoner(antalLoner);
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTryck ner valfri tangent för ny beräkning - ESC avslutar");
                Console.ResetColor();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            
        }

        static int LasInt(string prompt)
        {

            string braNummer = String.Empty;
            int antalLoner = 0;

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    braNummer = Console.ReadLine();
                    antalLoner = int.Parse(braNummer);
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! '{0}' kan inte tolkas som ett heltal!", braNummer);
                    Console.ResetColor();
                    
                }
            }
            return antalLoner;

        }

        static void HanteraLoner(int antalLoner)
        {
            int[] loner = new int[antalLoner];
            Console.WriteLine();
            for (int i = 0; i < antalLoner; i++)
            {
                Console.Write("Ange Lön nummer {0}: ", i + 1);
                loner[i] = int.Parse(Console.ReadLine());
            }
            int[] sortLoner = new int[antalLoner];

            Array.Copy(loner, sortLoner, antalLoner);
            Array.Sort(sortLoner);

            double medianLon = 0.0;
            double medelLon = sortLoner.Average();
            double loneSpridning = sortLoner.Max() - sortLoner.Min();

            if (sortLoner.Length % 2 == 1)
            {
                medianLon = sortLoner[sortLoner.Length / 2];
            }
            else
            {
                medianLon = sortLoner[sortLoner.Length/2] - 1;
            }

            Console.WriteLine();

            for (int i = 0; i < 40; i++)
            {
                Console.Write("-");
            }
            
            Console.WriteLine("\n{0} : {1,13:C0}", "Medianlön", medianLon);
            Console.WriteLine("{0} : {1,14:C0}", "Medellön", medelLon);
            Console.WriteLine("{0} : {1:C0}\n", "Lönespridning", loneSpridning);
            
            for (int j = 0; j < 40; j++)
            {
                Console.Write("-");
            }
            int raknare = 0;

            foreach (int loop in loner)
            {
                if (raknare%3 == 0)
                    {
                        Console.WriteLine();
                        Console.Write("{0,8}", loop);
                        raknare++;
                    }
                    else
                    {
                        Console.Write("{0,8}", loop);
                        raknare++;
                    }
            }
            Console.WriteLine();
        }
    }
}
