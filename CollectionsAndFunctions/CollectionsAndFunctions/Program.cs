// See https://aka.ms/new-console-template for more information


using Learn;
using RandomStringUtils;

// a local function (allowed only in Program.cs)
int F(int x) { return x + 1; }

void demoF() { 
    int y = F(0);
    Console.WriteLine(y);
}

void demoEuclide() { 
    uint a = 21; // 7*3
    uint b = 14; // 7*2
    uint g = Euclide.Gcd(a, b);
    Console.WriteLine(g);

    // Console.WriteLine(Euclide.Gcd(-1, 2)); // compilation error with uint

    // Console.WriteLine(Euclide.Gcd(0, 2)); // exception
}

void demoListLinQ()
{
    List<uint> list1 = [1, 4, 12, 16]; // c#12
    List<uint> list2 = new List<uint> { 1, 4, 12, 16 };
    List<uint> list3 = new List<uint>(); // empty list 

    // linq query ('SQL' mode)
    var extract = from v in list2
                  where v % 2 == 0
                  select v;
    foreach (var v in extract) { Console.Write(v + " "); }
    Console.WriteLine();

    // linq query (functional mode)
    // https://learn.microsoft.com/en-us/dotnet/csharp/linq/query-a-collection-of-objects#classification-table
    var extract2 = list2.Where(x => x % 2 == 0)
                        .ToList()
                        ;
    foreach (var v in extract2) { Console.Write(v + " "); }
    Console.WriteLine();

    var totalEven = list2.Where(x => x % 2 == 0)
        .Sum(x => x);
    Console.WriteLine(totalEven);
}

void demoContainers()
{
    // 1 - arrays
    // static array
    string[] menu = {"Burger Crevette", "Vin blanc", "Frite", "Chicken Wings"};
    // dynamic array (size can be read just before)
    string[] bigMenu = new string[1000]; // then fill it
    for (int i = 0; i < bigMenu.Length; i++)
    {
        bigMenu[i] = RandomStringUtils.RandomStringUtils.RandomAlphabetic(5);
    }
    string[] bigMenu2 = Enumerable.Range(0, 1000)
        .Select(i => RandomStringUtils.RandomStringUtils.RandomAlphabetic(5 + (i % 3)))
        .ToArray();
    // Poor displays...
    // Console.WriteLine("Menu #{0}#", menu); // first element
    // Console.WriteLine(menu); // type only
    
    // Better display
    DisplayUtil.WriteLine(menu);
    DisplayUtil.WriteLine(bigMenu);
    DisplayUtil.WriteLine(bigMenu2);

    // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-8.0
    // copy array into:
    // - list
    // - linkedlist
    // - sortedSet
    // display them
    List<string> menuList = new List<string>(bigMenu);
    LinkedList<string> menuList2 = new LinkedList<string>(menuList);
    SortedSet<string> menuSet = new SortedSet<string>(menuList);

    // menuList.ForEach(x => Console.WriteLine(x));
    DisplayUtil.WriteLine(menuList);
    DisplayUtil.WriteLine(menuList2);
    DisplayUtil.WriteLine(menuSet);

}

void demoCities()
{
    City city = new City {
        Name = "Toulouse",
        Area = 118.3,
        Population = 504_078,
    };
    HashSet<City> citySet = new HashSet<City> {
        new City
        {
            Name = "Bordeaux",
            Area = 49.36,
            Population = 261_804,
        },
        new City
        {
            Name = "Pau",
            Area = 31.51,
            Population = 77_066,
        },
        new City
        {
            Name = "Montpelier",
        },
    };
    citySet.Add(city);
    SortedSet<City> citySortedSet = new SortedSet<City>(citySet, 
        Comparer<City>.Create((c1, c2) => c1.Name.CompareTo(c2.Name)));
    DisplayUtil.WriteLine(citySortedSet);
}

//demoF();
//demoEuclide();
//demoListLinQ();

// demoContainers();
demoCities();
