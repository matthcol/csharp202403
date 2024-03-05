// See https://aka.ms/new-console-template for more information


using Learn;

// a local function (allowed only in Program.cs)
int F(int x) { return x + 1; }
int y = F(0);
Console.WriteLine(y);

int a = 21; // 7*3
int b = 14; // 7*2
int g = Euclide.Gcd(a, b);
Console.WriteLine(g);
