using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rita_med_asterisker_B
{
    class Program
    {
        const byte _maxValue = 79;
        const string prompt = "Ange det udda heltal asterisker mellan 1-79 i trianglens bas: ";
        const string keyInput = "\nTryck ner valfri tangent för ny beräkning - ESC avslutar";
        // const string inputValue = "";

        static void Main(string[] args)
        {            
            do
            {
                Console.Clear();
                byte maxCount = ReadOddByte(prompt);
                Console.WriteLine();
                RenderTriangle(maxCount);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(keyInput);
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static byte ReadOddByte(string prompt)
        {
            while (true)
            {
                string inputValue = string.Empty;
                Console.Write(prompt);
                inputValue = Console.ReadLine();
                try
                {
                    byte _number = byte.Parse(inputValue);
                    if (_number % 2 == 0 || _number > _maxValue)
                    {
                        throw new ArgumentException();
                    }                    
                    return _number;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! {0} är inte ett udda heltal mellan 1-79.\n", inputValue);
                    Console.ResetColor();
                }
            }
        }
        static void RenderTriangle(byte maxCount)
        {
            for (int i = 0; i < maxCount; i += 2)
            {
                switch (i % 3)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                for (int spaces = maxCount-i; spaces >= 0; spaces -=2)
                {
                    Console.Write(" ");
                }
                for (int asteriskCount = 0; asteriskCount <= i; asteriskCount++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.ResetColor();
            }            
        }
    }
}

