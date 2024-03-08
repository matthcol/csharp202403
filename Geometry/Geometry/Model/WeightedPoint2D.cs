using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Geometry.Model
{
    public class WeightedPoint2D: Point2D
    {
        public double Weight { get; set; }

        public override string ToString() => 
            $"{nameof(WeightedPoint2D)}[Name={Name}; X={X:0.00}; Y={Y:0.00}; Weight={Y:0.00}]";
    }
}
