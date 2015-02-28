﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gissa_Talet_MVC_A.Models
{
    public class SecretNumber
    {
        //Fält
        private List<GuessedNumber> _guessedNumbers; // Fält som innehåller godkända gissningar med Outcome High, Low el Right
        private GuessedNumber _lastGuessedNumber; // Fält som innehåller den senaste gissningen med utfallet
        private int? _number; // Ska innehålla det hemliga numret via slumpning
        public const int MaxNumberOfGuesses = 7; // Definerar hur många gissningar du har på dig att gissa

        // Egenskaper
        public string OutcomeGuess { get; set; }
        public string GuessNr { get { return PrintGuesses(Count); } }
        public bool CanMakeGuess // ger sant / falskt ifall det går att gissa eller inte
        {
            get { return MaxNumberOfGuesses == Count ? false : true; }
        }
        public int Count { get { return _guessedNumbers.Count; } } // Ger antal gjorda gissningar 
        public IList<GuessedNumber> Guessednumbers // 
        {
            get { return _guessedNumbers.AsReadOnly(); }
        }
        public GuessedNumber LastGuessedNumber // Håller reda på senaste utfallet och värdet
        {
            get { return _lastGuessedNumber; }
        }
        public int? Number // Publik egenskap som ska presentera det hemliga talet när alla gissningar gjorts
        {
            get { return !CanMakeGuess ? _number : null; }
            private set { _number = value; }
        }

        // Metoder
        public string PrintGuesses(int count) // Metod som presenterar hur många gissningar användaren gjort och vilket försök man klarade det på
        {
            string _guessNr = string.Empty;
            if (count > 0)
            {                
                switch (count)
                {
                    case 1: _guessNr = "Första";
                        break;
                    case 2: _guessNr = "Andra";
                        break;
                    case 3: _guessNr = "Tredje";
                        break;
                    case 4: _guessNr = "Fjärde";
                        break;
                    case 5: _guessNr = "Femte";
                        break;
                    case 6: _guessNr = "Sjätte";
                        break;
                    case 7: _guessNr = "Sjunde";
                        break;                    
                }                
                if (_lastGuessedNumber.Outcome != Outcome.Right)
                {
                    _guessNr += " gissningen";
                }
            }            
            return _guessNr;
        }
        public void Initialize()
        {
            _guessedNumbers.Clear();
            _lastGuessedNumber.Outcome = Outcome.Undefined;
            Random random = new Random();
            Number = random.Next(1, 100);
        }
        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            _lastGuessedNumber = new GuessedNumber { Number = guess };
            
            if (CanMakeGuess)
            {
                if (_guessedNumbers.Any(x => x.Number == guess))
                {
                    _lastGuessedNumber.Outcome = Outcome.OldGuess;
                    OutcomeGuess = string.Format("Du har redan gissat på {0}, välj ett annat tal!", guess);
                }
                else
                {                    
                    if (guess > _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.High;
                        OutcomeGuess = string.Format("{0} är för högt!", guess);
                    }
                    else if (guess < _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.Low;
                        OutcomeGuess = string.Format("{0} är för lågt!", guess);
                    } 
                    else if (guess == _number)
                    {                        
                        _lastGuessedNumber.Outcome = Outcome.Right;
                        string rightAnswer = PrintGuesses(Count + 1); // Räknar upp rätt försök när användare anger rätt tal 
                        OutcomeGuess = string.Format("Grattis! Du klarade det på {0} försöket!", rightAnswer.ToLower());
                    }
                    _guessedNumbers.Add(_lastGuessedNumber);                                       
                }                
            }
            if (!CanMakeGuess && LastGuessedNumber.Outcome != Outcome.Right)
            { 
                _lastGuessedNumber.Outcome = Outcome.NoMoreGuesses;
                OutcomeGuess = string.Format("{0} Inga fler gissningar! Det hemliga talet är {1}", OutcomeGuess, _number);
            }
            return _lastGuessedNumber.Outcome;
        }

        // Konstruktor
        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            Initialize();
        }


    }
}