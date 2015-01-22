using System;

namespace Laboration4.A
{
    public class SecretNumber
    {
        private int _count;

        private int _number;

        public const int MaxNumberOfGuesses = 7;

        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 100);
            _count = 0;

        }

        public bool MakeGuess(int number)
        {
            
            if (number >= 101 || number <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }
            
            if (number > _number)
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - (_count+1));
                _count++;

                if (_count == MaxNumberOfGuesses)
                {
                    Console.WriteLine("Det hemliga talet är {0}.", _number);
                }
                return false;
            }
            
            if (number < _number)
            {
                Console.WriteLine("{0} är för lågt! Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - (_count+1));
                _count++;
                if (_count == MaxNumberOfGuesses)
                {
                    Console.WriteLine("Det hemliga talet är {0}.", _number);
                }
                return false;
            }
            
            
            Console.WriteLine("Härligt Jobbat! Du klarade det på {0} försök.", _count+1);
            Console.WriteLine("Det hemliga talet var {0}.", _number);
            return true;
        }

        public SecretNumber()
        {
            Initialize();
        }


    }
}
