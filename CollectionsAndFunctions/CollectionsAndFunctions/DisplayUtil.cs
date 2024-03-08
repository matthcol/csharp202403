using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Learn
{
    public static class DisplayUtil
    {
        // display array of string
        // if length > 10, display first 5, last 5
        // Hint: Range
        public static void WriteLine0(string[] strings)
        {
            if (strings.Length <= 10)
            {
                foreach (string s in strings)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }
            else
            {
                foreach (string s in strings[..5]) {
                Console.Write(s + " ");
                }
                Console.Write("...");
                foreach (string s in strings[^5..])
                {
                    Console.Write(s + " ");
                }
            }
        }

        public static void WriteLine<T>(ICollection<T> collection)
        {
            if (collection.Count <= 10) { WriteCommon(collection); }
            else
            {
                WriteCommon(collection.Take(5));
                Console.Write("...");
                WriteCommon(collection.TakeLast(5));
            }
            Console.WriteLine();
        }

        public static void WriteLine<T>(T[] array)
        {
           if (array.Length <= 10) { WriteCommon(array); }
           else {
                WriteCommon(array[..5]);
                Console.Write("...");
                WriteCommon(array[^5..]);
            }
           Console.WriteLine();
        }

        private static void WriteCommon<T>(IEnumerable<T> enumerable)
        {
            foreach (var t in enumerable) { Console.Write(t + " ");}
        }


    }
}
