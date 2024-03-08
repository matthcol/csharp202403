using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Model
{

    // 1 - Form, IMesurable2D as a prototype
    // 2 - add 1 form in Program.cs
    // 3 - add Property summmits and adapt Translate, Area, Perimeter
    public class Polygon : Form, IMesurable2D
    {
        public IList<Point2D> Vertices { get; set; }

        public int VertexCount => Vertices.Count;

        public double Perimeter
        {
            get
            {
                double res = 0.0;
                Point2D previous = Vertices[^1]; // Summits.Last();
                foreach (Point2D current in Vertices)
                {
                    res += current.Distance(previous);
                    // for next iteration
                    previous = current;
                }
                // add all distances: 0-1, 1-2, 2-3, 3-4, ...., last-0
                return res;
            }
        }

        public double Area
        {
            get {
                // NB: only works for convexe polygon
                // TODO: concave/convexe =>
                //      - add/substract triangleArea according to the sign of the angle
                //      - return abs(res)
                // TODO: crossed => exception or other computation
                double res = 0.0;
                var pt0 = Vertices[0];
                // sum of triangle decomposition areas
                for (int i = 1; i <= VertexCount - 2; i++)
                {
                    var pt1 = Vertices[i];
                    var pt2 = Vertices[i+1];
                    double d1 = pt0.Distance(pt1);
                    double d2 = pt1.Distance(pt2);
                    double d3 = pt2.Distance(pt0);
                    double triangleArea = HeronFormula(d1, d2, d3);
                    res += triangleArea;
                }
                return res;
            }
        }

        public override void Translate(double deltaX, double deltaY)
        {
            foreach (var summit in Vertices) 
            {
                summit.Translate(deltaX, deltaY);
            }
        }

        public override string ToString()
        {
            var names = string.Join("-", Vertices.Select(v => v.Name));
            return $"{nameof(Polygon)}[VertexCount={VertexCount} ; Vertices={names}]";
        }

        public static double HeronFormula(double a, double b, double c)
        {
            // non optimized version of the formula
            // cf: https://en.wikipedia.org/wiki/Heron%27s_formula
            var semiPerimeter = (a + b + c) / 2;
            return Math.Sqrt(
                semiPerimeter
                * (semiPerimeter - a)
                * (semiPerimeter - b)
                * (semiPerimeter - c)
            );
        }

    }
}
