using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    public static class Euclide
    {
        /// <summary>
        /// Compute greatest common divisor of 2 natural integers a and b.
        /// </summary>
        /// <param name="a">first number (strictly positive)</param>
        /// <param name="b">second number (strictly positive)</param>
        /// <returns>greatest common divisor</returns>
        /// <exception cref="ArgumentException">if at least one argument is 0</exception>
        public static uint Gcd(uint a, uint b)
        {
            if ((a == 0) || (b == 0))
            {
                throw new ArgumentException("args must be strictly positive");
            }
            while (a != b)
            {
                if (a> b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
;        }
    }
}
