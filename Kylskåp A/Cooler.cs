using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kylskåp_A
{
    class Cooler
    {
        // Fält
        private decimal _insideTemperature = 0.0m;
        private decimal _targetTemperature = 0.0m;
        // Konstant
        private const decimal OutsideTemperature = 23.7m;

        // Egenskaper
        public bool DoorIsOpen { get; set; }
    
        public decimal InsideTemperature
        {
            get { return _insideTemperature; }
            set
            {
                if (value < 0 || value > 45)
                {
                    throw new ArgumentException();
                }
                _insideTemperature = value;
            }
        }

        public bool IsOn { get; set; }
        
        public decimal TargetTemperature
        {
            get { return _targetTemperature; }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentException();
                }
                _targetTemperature = value;
            }
        }

        // Konstruktor
        public Cooler()
            : this(0m,0m){ } // Anropar konstruktorn med 2 argument

        public Cooler(decimal temperature, decimal targetTemperature)
            : this(temperature, targetTemperature, false, false) { }  // Anropar konstruktorn med 4 argument

        public Cooler(decimal temperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
        {
            InsideTemperature = temperature;
            TargetTemperature = targetTemperature;
            IsOn = isOn; 
            DoorIsOpen = doorIsOpen;
        }

        public void Tick() // Publik metod för att simulera händelser vid PÅ/AV och med Dörr Öppen/Stängd
        {
            decimal setPoint = 0.0m;

            if (IsOn == true && DoorIsOpen == false)
            {
                setPoint -= 0.2m;
            }
            
            else if (IsOn == true && DoorIsOpen == true)
            {
                setPoint += 0.2m;
            }
            
            else if (IsOn == false && DoorIsOpen == true)
            {
                setPoint += 0.5m;
            }
            else
            {
                setPoint += 0.1m;
            }
                                    
            if(InsideTemperature + setPoint < TargetTemperature)
            {
                InsideTemperature = TargetTemperature;
            }
            else if (InsideTemperature + setPoint > OutsideTemperature)
            {
                InsideTemperature = OutsideTemperature;
            }
            else 
            {
                InsideTemperature += setPoint;
            }
            
        }

        public override string ToString() // Returnerar resultat ifrån Innetempraturen, Måltempraturen, Kylskåp PÅ/AV och Dörr Öppen/Stängd
        {
            string OnOff = IsOn ? "PÅ" : "AV";
            string OpenClosed = DoorIsOpen ? "Öppen" : "Stängd";
            return string.Format("[{0}] : {1:f1}°C : <{2:f1}°C> : {3}", OnOff, InsideTemperature, TargetTemperature, OpenClosed);
        }

        
        
    }
}
		
