using System;

namespace kassakvitto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "KassaKvitto Nivå A";
            //deklarerar variabler
            double totSumma = 0;
                        
            //läser in talen
            Console.Write("Ange totalpriset: ");
            totSumma = double.Parse(Console.ReadLine());

            // Felhantering på totalpriset, ifall köpesumman är för liten
            if (totSumma < 0.5)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            int betalning = 0;
            int oresUtjamning = (int)Math.Round(totSumma);
            
            while (true) 
            {
                try // Hanterar felinmatningar och för små belopp
                {
                    Console.Write("Ange erhållet belopp: ");
                    betalning = int.Parse(Console.ReadLine());
                    
                    if (betalning < oresUtjamning)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Erhållet belopp är inte tillräckligt. Köpet kan inte genomföras");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }
                    // Bryter loopen för att gå vidare vid rätt belopp
                    break;
                }

                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Värdet kan inte tolkas som ett belopp");
                    Console.ResetColor();
                }
            }             
             
            double oresAvrundning = oresUtjamning - totSumma;
            int vaxel = betalning - oresUtjamning;
            
            // Skriver ut kvittot på skärmen
            Console.WriteLine("\n\nKVITTO");
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("{0,-20} : {1,10:c}", "Totalt", totSumma);
            Console.WriteLine("{0,-20} : {1,10:c}", "Öresavrundning", oresAvrundning);
            Console.WriteLine("{0,-20} : {1,10:c0}", "Att Betala", oresUtjamning);
            Console.WriteLine("{0,-20} : {1,10:c0}", "Kontant", betalning);
            Console.WriteLine("{0,-20} : {1,10:c0}", "Tillbaka", vaxel);

            Console.WriteLine("-------------------------------------------\n\n");

            //deklarera fältvariabler
            int resterandeSumma = 0;

            // Räknar ut växelpengar av dess olika antal som kund ska få tillbaka
            if (vaxel > 0)
            {
                int antalfemHundra = vaxel / 500;
                resterandeSumma = vaxel % 500;
                int antalettHundra = resterandeSumma / 100;
                resterandeSumma %= 100;
                int antalfemtior = resterandeSumma / 50;
                resterandeSumma %= 50;
                int antaltjugor = resterandeSumma / 20;
                resterandeSumma %= 20;
                int antaltior = resterandeSumma / 10;
                resterandeSumma %= 10;
                int antalfemmor = resterandeSumma / 5;
                resterandeSumma %= 5;
                int antalenKronor = resterandeSumma / 1;
                resterandeSumma %= 1;

                // Presenterar resultatet
                if(antalfemHundra > 0)
                {
                    Console.WriteLine("500-lappar : {0}\t st", antalfemHundra);
                } 
                if (antalettHundra > 0)
                {
                    Console.WriteLine("100-lappar : {0}\t st", antalettHundra);
                }
                if(antalfemtior > 0)
                {
                    Console.WriteLine("50-lappar  : {0}\t st", antalfemtior);
                }
                if(antaltjugor > 0)
                {
                    Console.WriteLine("20-lappar  : {0}\t st", antaltjugor);
                }
                if(antaltior > 0)
                {
                    Console.WriteLine("10-kronor  : {0}\t st", antaltior);
                } 
                if(antalfemmor > 0)
                {
                    Console.WriteLine("5-kronor   : {0}\t st", antalfemmor);
                }
                if(antalenKronor > 0)
                {
                    Console.WriteLine("1-kronor   : {0}\t st", antalenKronor);
                }
            }
            else
            {
                Console.WriteLine("Det var jämna pengar!");
                Console.WriteLine("Ha en bra dag!");
            }
        }
    }
}
