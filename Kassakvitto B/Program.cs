using System;

namespace kassaKvittoB
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Title = "KassaKvitto B";

                decimal subSumma = LasPositvDouble("Ange totalsumman: ");
                decimal totSumma = (decimal)Math.Round(subSumma);
                decimal oresAvrundning = totSumma - subSumma;
                decimal betalat = LasDecimal("Ange erhållet belopp: ", totSumma);
                int vaxel = (int)betalat - (int)totSumma;

                Console.WriteLine("\n\nKVITTO");
                Console.WriteLine("-------------------------------------------");

                Console.WriteLine("{0,-15}:{1,15:c}", "Totalt", subSumma);
                Console.WriteLine("{0,-15}:{1,15:c}", "Öresavrundning", oresAvrundning);
                Console.WriteLine("{0,-15}:{1,15:c0}", "Att Betala", totSumma);
                Console.WriteLine("{0,-15}:{1,15:c0}", "Kontant", betalat);
                Console.WriteLine("{0,-15}:{1,15:c0}", "Tillbaka", vaxel);

                Console.WriteLine("-------------------------------------------\n\n");

                DelaUppIFaktorer(vaxel);

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTryck ner valfri tangent för ny beräkning - ESC avslutar");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
        static decimal LasPositvDouble(string titel)
        {
            string input = string.Empty;
            decimal kostnad = 0.0m;

            while (true)
            {
                Console.Write(titel);
                input = Console.ReadLine();
                try
                {
                    kostnad = decimal.Parse(input);
                    if (kostnad < 1m)
                    {
                        throw new Exception();
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! '{0}' är inte giltigt belopp", input);
                    Console.ResetColor();
                }

            }
            return kostnad;
        }
        static decimal LasDecimal(string titel, decimal minVarde)
        {
            int inmatatBelopp = 0;
            string input = string.Empty;

            while (true)
            {
                Console.Write(titel);
                input = Console.ReadLine();
                try
                {
                    inmatatBelopp = int.Parse(input);
                    if (inmatatBelopp < minVarde)
                    {
                        throw new ArgumentException();
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Beloppet är mindre än {0}", minVarde);
                    Console.ResetColor();
                }
            }
            return inmatatBelopp;
        }

        static void DelaUppIFaktorer(int vaxel)
        {
            int[] valorer = { 500, 100, 50, 20, 10, 5, 1 };
            string[] valorUtskrift = { "-lappar", "-lappar", "-lappar", "-lappar", "-kronor", "-kronor", "-kronor" };
            
            int belopp = 0;

            for (int i = 0; i < valorer.Length; i++)
            {
                
                belopp = vaxel / valorer[i];
                
                vaxel %= valorer[i];

                
                if (belopp != 0)
                {
                    Console.WriteLine("{0, -12}:{1, 5}", valorer[i] + valorUtskrift[i], belopp);
                }
            }
        }
    }
}