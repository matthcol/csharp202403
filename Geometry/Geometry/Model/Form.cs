using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Model
{
    public abstract class Form
    {
        public String Name { get; set; } = "_";
        public abstract void Translate(double deltaX, double deltaY);
    }
}
