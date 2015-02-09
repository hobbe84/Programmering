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
            Console.Title = "Lönerevision Nivå A";
            int antalLoner;

            do // Hantering av löneantal och felhantering på värde mindre än 2
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
            string braNummer = string.Empty;
            int talHantering = 0;
            while (true) // Felhantering på input ifall du anger en sträng ist för ett heltal
            {
                try
                {
                    Console.Write(prompt);
                    braNummer = Console.ReadLine();
                    talHantering = int.Parse(braNummer);
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
            return talHantering;
        }
        static void HanteraLoner(int antalLoner)
        {
            int[] loner = new int[antalLoner];
            Console.WriteLine();
            for (int i = 0; i < antalLoner; i++) // Loopar Löneantalet och sparar värden i en array
            {
                string prompt = string.Format("Ange lön nummer {0}: ",i+1);
                loner[i] = LasInt(prompt);
            }
            int[] sortLoner = new int[antalLoner];
            Array.Copy(loner, sortLoner, antalLoner); // Kopierar nuvarande array till ny array och sorterar den
            Array.Sort(sortLoner);
            // deklarerar fältvariabler
            decimal medianLon = 0;
            double medelLon = sortLoner.Average();
            int loneSpridning = sortLoner.Max() - sortLoner.Min();            
            if (sortLoner.Length % 2 == 1) // Hanterar löneindex till medianvärde av jämna/udda värden
            {
                medianLon = sortLoner[sortLoner.Length / 2];
            }
            else
            {
                int jamn1 = sortLoner[sortLoner.Length / 2];
                int jamn2 = sortLoner[sortLoner.Length / 2 - 1];
                medianLon = (jamn1 + jamn2) / 2.0m;
            }
            Console.WriteLine();
            for (int i = 0; i < 40; i++)
            {
                Console.Write("-");
            }            
            Console.WriteLine("\n{0,-15} : {1,10:C0}", "Medianlön", medianLon);
            Console.WriteLine("{0,-15} : {1,10:C0}", "Medellön", medelLon);
            Console.WriteLine("{0,-15} : {1,10:C0}\n", "Lönespridning", loneSpridning);            
            for (int j = 0; j < 40; j++)
            {
                Console.Write("-");
            }
            int raknare = 0;
            foreach (int visaLoner in loner) // Loopar första arrayn med 3 index per rad
            {
                if (raknare%3 == 0)
                    {
                        Console.Write("\n{0,8}", visaLoner);
                        raknare++;
                    }
                    else
                    {
                        Console.Write("{0,8}", visaLoner);
                        raknare++;
                    }
            }
            Console.WriteLine();
        }
    }
}
