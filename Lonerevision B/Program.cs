using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonerevision_B
{
    class Program
    {
        const string HorizontalLine = "-";        
        static int GetDispersion(int[] source)
        {
            int salariesDispersion = source.Max() - source.Min();
            return salariesDispersion;
        }
        static decimal GetMedian(int[] source)
        {
            decimal medianSalery = 0m;
            if (source.Length % 2 == 1) // Hanterar löneindex till medianvärde av jämna/udda värden
            {
                medianSalery = source[source.Length / 2];
            }
            else
            {
                int evenIndex = source[source.Length / 2];
                int oddIndex = source[source.Length / 2 - 1];
                medianSalery = (evenIndex + oddIndex) / 2.0m;
            }
            return medianSalery;
        }
        static bool IsContinuing()
        {
            return Console.ReadKey(true).Key != ConsoleKey.Escape ? true : false;
        }
        static void Main(string[] args)
        {            
            do
            {
                Console.Clear();
                Console.CursorVisible = true;
                int numberOfSalaries = ReadPositiveInt("Ange antal löner att mata in: ");
                int[] salaries = new int[numberOfSalaries];
                if (numberOfSalaries < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDu måste mata in minst tvä löner för att kunna göra en beräkning!");
                    Console.ResetColor();                    
                }
                else
                {
                    salaries = ReadSalaries(numberOfSalaries);
                    ViewResult(salaries);
                }
                ViewMessage("\nTryck ner valfri tangent för ny beräkning - ESC avslutar", false);
            } while (IsContinuing());
        }
        private static int ReadPositiveInt(string prompt)
        {
            string numricalManagement = string.Empty;
            int positiveNumber = 0;

            while (true) // Felhantering på input ifall du anger en sträng el negativt värde ist för ett positivt heltal
            {
                Console.Write(prompt);
                numricalManagement = Console.ReadLine();
                try
                {
                    positiveNumber = int.Parse(numricalManagement);
                    if (positiveNumber < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    return positiveNumber;
                }
                catch (Exception)
                {
                    ViewMessage(numricalManagement, true);                    
                }
            }            
        }
        static int[] ReadSalaries(int count)
        {
            int[] salaries = new int[count];
            Console.WriteLine();
            for (int i = 0; i < count; i++) // Loopar Löneantalet och sparar värden i en array
            {
                string prompt = string.Format("Ange lön nummer {0}: ", i + 1);
                salaries[i] = ReadPositiveInt(prompt);
            }
            return salaries;
        }       
        static void ViewMessage(string message, bool isError)
        {
            if (isError == true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nFEL! '{0}' kan inte tolkas som ett heltal\n", message);
                Console.ResetColor();
            }
            else
            {
                Console.CursorVisible = false;
                Console.BackgroundColor = ConsoleColor.Blue;                
                Console.WriteLine(message);
                Console.ResetColor();                
            }
        }
        static void ViewResult(int[] salaries)
        {
            int[] salariesSorted = new int[salaries.Length]; // Initerar en ny array 
            Array.Copy(salaries, salariesSorted, salaries.Length); // Kopierar nuvarande array till ny array och sorterar den
            Array.Sort(salariesSorted);
            decimal medianSalery = GetMedian(salariesSorted);
            double averageSalery = salariesSorted.Average();
            decimal saleryDisperion = GetDispersion(salariesSorted);
            Console.WriteLine();
            for (int i = 0; i < 40; i++)
            {
                Console.Write(HorizontalLine);
            }
            Console.WriteLine("\n{0,-15} : {1,10:C0}", "Medianlön",medianSalery);
            Console.WriteLine("{0,-15} : {1,10:C0}", "Medellön", averageSalery);
            Console.WriteLine("{0,-15} : {1,10:C0}", "Lönespridning", saleryDisperion);
            for (int i = 0; i < 40; i++)
            {
                Console.Write(HorizontalLine);
            }
            int counter = 0;
            foreach (int showSaleries in salaries) // Loopar första arrayn med 3 index per rad
            {
                if (counter % 3 == 0)
                {
                    Console.Write("\n{0,8}", showSaleries);
                    counter++;
                }
                else
                {
                    Console.Write("{0,8}", showSaleries);
                    counter++;
                }
            }
            Console.WriteLine();            
        }       
    }
}
