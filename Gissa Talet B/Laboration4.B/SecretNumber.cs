using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.B
{
    public class SecretNumber
    {
        // Fält
        private int[] _guessedNumbers; // Innehåller antal gissningar
        private int _number; // Innehåller det hemliga talet
        public const int MaxNumberOfGuesses = 7; // Antal gissningar tillåtet att gissa
        // Egenskaper
        public bool CanMakeGuess // Kollar ifall användaren får gissa eller inte
        {
            get { return Count >= MaxNumberOfGuesses || _guessedNumbers[Count] == _number ? false : true; }
            private set { }
        }
        public int Count { get; private set; } // Håller reda på hur många gissningar som har gjorts 
        public int GuessesLeft // Håller reda på antal gissningar kvar
        {
            get { return MaxNumberOfGuesses - Count; }
        }
        //Metoder
        public void Initialize() // Metod för att slumpa fram nytt hemligt tal och nollställa alla värden
        {
            Array.Clear(_guessedNumbers, 0, _guessedNumbers.Length);
            Random random = new Random();
            _number = random.Next(1, 101);
            Count = 0;
            CanMakeGuess = true;
        }
        public bool MakeGuess(int number) // Kollar ifall värden är för högt el låg osv och meddelar utfallet
        {
            if (number >= 101 || number <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (!CanMakeGuess)
            {                
                throw new ApplicationException();                
            }
            if (CanMakeGuess)
            {
                int oldGuess = Array.IndexOf(_guessedNumbers, number);
                if (oldGuess != -1)
                {
                    Console.WriteLine("Du har redan gissat {0}, Försök igen!", number);
                    return false;
                }
                else
                {
                    _guessedNumbers[Count] = number;
                    Count++;                    
                }
                if (number > _number)
                {
                    Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, GuessesLeft);                    
                }
                else if (number < _number)
                {
                    Console.WriteLine("{0} är för lågt! Du har {1} gissningar kvar.", number, GuessesLeft); 
                }
                if (number == _number) 
                {
                    Console.WriteLine("Härligt Jobbat! Du klarade det på {0} försök.", Count);
                    Console.WriteLine("Det hemliga talet var {0}.", _number);
                    Count--; // Får räkna ner Count då egenskapen kollar värdet mot index[Count] i arrayen
                    return true;
                }
                else if (Count == MaxNumberOfGuesses)
                {
                    Console.WriteLine("Det hemliga talet var {0}", _number);
                }
            }
            return false;
        }
        // Konstruktor
        public SecretNumber()
        {
            _guessedNumbers = new int[MaxNumberOfGuesses];
            Initialize();
        }
    }
}
