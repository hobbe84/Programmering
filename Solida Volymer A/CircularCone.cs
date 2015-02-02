using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solida_Volymer_A
{
    class CircularCone : Solid
    {
        public override double BaseArea // Räknar ut konens basarea
        {
            get { return RadiusSquared * Math.PI; }
        }
        public override double SurfaceArea // Räknar ut konens ytarea
        {
            get { return (Radius + Math.Sqrt(RadiusSquared + HeightSquared)) * Radius * Math.PI; }
        }
        public override double Volume // Räknar ut konens volym
        {
            get { return Height * RadiusSquared * (Math.PI / 3.0); }
        }
        public CircularCone(double radius, double height)
            : base(radius, height) // Anropar Solids konstuktor
        {}
    }
}
