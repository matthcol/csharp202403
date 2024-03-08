using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Model
{
    public class Point2D: Form
    {
        public double X { get; set; }
        public double Y { get; set; }

        public override void Translate(double deltaX, double deltaY)
        {
            X += deltaX;
            Y += deltaY;    
        }

        public double Distance(Point2D other) {
            //return Double.Hypot(this.X - other.X, this.Y - other.Y);
            return Math.Sqrt(Math.Pow(this.X - other.X, 2) + Math.Pow(this.Y - other.Y, 2));
        }

        public override string ToString()
        {
            // return $"{Name}({X:0.00};{Y:0.00})";
            return $"{nameof(Point2D)}[{nameof(Name)}={Name}; {nameof(X)}={X:0.00}; {nameof(Y)}={Y:0.00}]";
        }
    }
}
