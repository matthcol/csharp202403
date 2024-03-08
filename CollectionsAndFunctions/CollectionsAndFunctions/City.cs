using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    public class City
    {
        //private string _name;

        //private string Name
        //{
        //    get => _name;
        //    set
        //    {
        //        if (value.Length <= 1) throw new ArgumentException("name length must be at least 1");
        //        _name = value;
        //    }
        //}

        public string Name { get; set; } = "undefined";
        public double Area { get; set; } = Double.NaN;
        public long Population { get; set; }

        public override string ToString() { return $"{Name} ({Area} km2, {Population} hab)"; }
    }
}
