// See https://aka.ms/new-console-template for more information
using Basics;
using System.Collections.Generic;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.WriteLine("Hello, World!");

// builtin types, simple  types
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types

// integers
// floats (virgule flottante): float, double
// decimal (virgule fixe)

// int (C#) = System.Int32 (.NET)
// integer type = range
// 2^8 = 256: 0 to 255 
// 2^10 = 1024
// 2^16 ~ 65K
// 2^32 ~ 4G: 0 to 4G (uint32), 2G to 2G (int32)
// 2^64 ~ 18E (milliard de milliard)
int x = 12;
Int32 y = 13;
Int32 z = x + y;

// int w = 5_000_000_000; // too big for int32

// floats
double price = 0.1;
Console.WriteLine("prices: one = {0} ; two = {1} ; three = {2}", price, 2*price, 3*price);
Console.WriteLine("prices: one = {0:0.00} ; two = {1:0.00} ; three = {2:0.00}", price, 2 * price, 3 * price);

// boolean
bool isSunny = true;
bool isCheap = price < 1.0; // tests: < <= > >= == !=

char c = 'A';

// .NET: classes 

// text: string/String (Unicode)
string city = "Toulouse";
string city2 = "東京";
string modernText = "parrot 🦜";
Console.WriteLine("{0} {1} {2}", city, city2, modernText);
// vocabulary: string is a class, city/city2, modernText are objects of class string
// city = instance of class string

// Exo: upper, lower, longueur, 4 premiers caractères, 4 derniers, est-ce que ça commence par T
// - le faire sur la vairable city
// - le faire sur les 3 variables city, city2, modernText

// method without args
Console.WriteLine(city.ToUpper());
Console.WriteLine(city.ToLower());
// property/field
Console.WriteLine(city.Length);
// method with args
Console.WriteLine(city.Substring(0, 4)); // first 4 chars
Console.WriteLine(city.Substring(city.Length - 4)); // first 4 chars
Console.WriteLine(city.StartsWith("T"));
Console.WriteLine();

IEnumerable<string> words = new List<string>{ 
    city, 
    city2, 
    modernText 
};
foreach (string text in words)
{
    Console.WriteLine("Play with word: {0}", text);
    Console.WriteLine(text.ToUpper());
    Console.WriteLine(text.ToLower());
    // property/field
    Console.WriteLine(text.Length);
    // method with args
    if (text.Length >= 4)
    {
        // first 4 chars
        Console.WriteLine("{0} / {1}", 
            text.Substring(0, 4), 
            text[..4]   // with range
        );
        // first 4 chars
        Console.WriteLine("{0} / {1}", 
            text.Substring(text.Length - 4), 
            text[^4..] // with range indexed from the end
        );
    } else
    {
        Console.WriteLine("Less than 4 'characters'");
    }
    Console.WriteLine(text.StartsWith("T"));
    Console.WriteLine();
}
string line = "⛰️,🦜,🌊";
foreach (string word in line.Split(',')) { Console.WriteLine(word); }

Telephone tel1 = new Telephone();
Console.WriteLine("Tel: {0} -> {1}",
    tel1  // call tel1.ToString()
    , tel1.Number
); 
Telephone tel2 = new Telephone { Number = "333-333-333" };
Console.WriteLine("Tel: {0} -> {1}",
    tel2  // call tel1.ToString()
    , tel2.Number
);

// operators
Console.WriteLine(((price * 20_000) - 2.5) / 1.5 + 1.5);
Console.WriteLine("7 / 3 => q = {0}, r = {1}", 7 / 3, 7 % 3);
Console.WriteLine("7 / 3.0 = {0}", 7 / 3.0);

// class method (static)
double res = Math.Sqrt(9.0);
Console.WriteLine(res);

Console.WriteLine(DateTime.Now);
DateTime dt = DateTime.Now;
Console.WriteLine(dt.Year);
// dt.Year = 2032; // no setter

DateTime dt2 = new DateTime(2024, 2, 29);
Console.WriteLine(dt2);
Console.WriteLine(dt2.Day);

// formatted string, string interpolation
Console.WriteLine($"price = {price} ; price (2 digits) = {price:0.00}");
Console.WriteLine($"Now: year = {dt.Year} ; month = {dt.Month} ; day = {dt.Day}");
// before
Console.WriteLine(String.Format("price = {0} ; price (2 digits) = {0:0.00}", price));