using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Model
{
    public class Circle : Form, IMesurable2D
    {
        public double Radius { get; set; } 
        public Point2D Center { get; set; }

        public double Perimeter => 2*Math.PI*Radius;

        public double Area => Math.PI * Radius * Radius;

        public override void Translate(double deltaX, double deltaY)
        {
            Center.Translate(deltaX, deltaY);
        }

        public override string ToString() =>
            $"{nameof(Circle)}[Name={Name}; Radius={Radius}; Center={Center.Name}]";
        
    }
}
