using System;

namespace kassakvitto
{
    class Program
    {
        static void Main(string[] args)
        {   
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
                Environment.Exit(0);
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
                        Environment.Exit(0);
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

            Console.WriteLine("Totalt         : {0:f2}\tkr", totSumma);
            Console.WriteLine("Öresavrundning : {0:f2}\t\tkr", oresAvrundning);
            Console.WriteLine("Att betala     : {0}\t\tkr", oresUtjamning);
            Console.WriteLine("Kontant        : {0}\t\tkr", betalning);
            Console.WriteLine("Tillbaka       : {0}\t\tkr", vaxel);

            Console.WriteLine("-------------------------------------------\n\n");

            //deklarera variabler
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
            // Väntar på userinput innan programmet avslutats
            Console.ReadKey();
        }
    }
}
