using Geometry.Model;

void DemoIMesurable2D(IEnumerable<IMesurable2D> mesurable2Ds) 
{
    Console.WriteLine("*** Mesurable 2D ***");
    foreach(var mesurable2D in mesurable2Ds)
    {
        double a = mesurable2D.Area;
        double p = mesurable2D.Perimeter;
        Console.WriteLine($"{mesurable2D}: area = {a:0.00} ; perimeter = {p:0.00}");
    }
}

void DemoForms()
{
    Point2D ptO = new Point2D();
    Point2D ptA = new Point2D
    {
        Name = "A",
        X = 1.5,
        Y = 2.25
    };
    var ptB = new Point2D
    {
        Name = "B",
        X = 4.5,
        Y = -1.75
    };
    var wptE = new WeightedPoint2D
    {
        Name = "E",
        X = 12.75,
        Y = 5.25,
        Weight = 2.0
    }; 
    // Form form; // = new Form(); // Error (abstract class not instantiable)
    var circleC1 = new Circle 
    { 
        Name = "C1", 
        Radius = 10.0,
        Center = ptA
    };
    var circleC2 = new Circle
    {
        Name = "C2",
        Radius = 25.0,
        Center = wptE
    };

    List<Point2D> points = [ptO, ptA, ptB, wptE];
    List<Form> forms = new List<Form>(points);
    forms.Add(circleC1);
    forms.Add(circleC2);
    var circles = Enumerable.Range(1, 10)
        .Select(i => new Circle()
        {
            Name = $"C{i}",
            Radius = i,
            Center = ptO
        });
    forms.AddRange(circles);

    var poly1 = new Polygon()
    {
        Name = "P1",
        // Summits = [ ptO, ptA, ptB ]
        Vertices = new List<Point2D>() { ptO, ptA, ptB }
    };
    forms.Add(poly1);

    Console.WriteLine("*** Forms ***");
    forms.ForEach(f => Console.WriteLine(f));
    Console.WriteLine();

    ptB.Translate(1.0, -1.0);
    circleC1.Translate(5.0, 4.5);
    Console.WriteLine("After single translations: {0}, {1}", ptB, circleC1);
    Console.WriteLine();

    // points.ForEach(f => f.Translate(100.0, 100.0));
    // filter by type
    var pointsOnly = forms
        .OfType<Point2D>();
        //.Where(f => f is Point2D)
        //.Cast<Point2D>();
    foreach (var f in pointsOnly)
    {
        f.Translate(100.0, 100.0);
    }
    Console.WriteLine("*** Forms ***");
    forms.ForEach(f => Console.WriteLine(f));
    Console.WriteLine();

    double d1 = ptA.Distance(ptB);
    double d2 = ptB.Distance(ptA);
    double d3 = wptE.Distance(ptA);
    double d4 = ptA.Distance(wptE);
    double d5 = wptE.Distance(wptE);
    Console.WriteLine($"Distance {ptA.Name}-{ptB.Name} = {d1}");
    Console.WriteLine($"Distance {ptB.Name}-{ptA.Name} = {d2}");
    Console.WriteLine($"Distance {wptE.Name}-{ptA.Name} = {d3}");
    Console.WriteLine($"Distance {ptA.Name}-{wptE.Name} = {d4}");
    Console.WriteLine($"Distance {wptE.Name}-{wptE.Name} = {d5}");
    Console.WriteLine();

    // extract IMesurable2D objects
    var mesurable2ds = forms.OfType<IMesurable2D>();
    DemoIMesurable2D(mesurable2ds);

    Console.WriteLine();
}

void DemoSubstitution()
{
    var ptA = new Point2D{
        Name = "A",
        X = 1.5,
        Y = 2.25
    };
    Form f = ptA;
    if (f is Point2D)
    {
        Point2D pt = (Point2D)f; // ClassCastException if cast impossible
        // use pt as a Point2D
        Console.WriteLine((pt.X + pt.Y) / 2);
    }
    Point2D? pt2 = f as Point2D;
    if (pt2 is not null)
    {
        // use pt2 as a Point2D
        Console.WriteLine((pt2.X + pt2.Y) / 2);
    }
}

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
void DemoZip()
{
    Point2D ptA = new Point2D
    {
        Name = "A",
        X = 1.5,
        Y = 2.25
    };
    var ptB = new Point2D
    {
        Name = "B",
        X = 4.5,
        Y = -1.75
    };
    var wptE = new WeightedPoint2D
    {
        Name = "E",
        X = 12.75,
        Y = 5.25,
        Weight = 2.0
    };

    List<Point2D> list1 = new (){ ptA, ptA, ptB, wptE, wptE, ptA };
    List<Point2D> list2 = new() { ptA, ptB, ptA, wptE, ptA, wptE };
    
    var distances = list1.Zip(list2)
        .Select(pointPair => pointPair.First.Distance(pointPair.Second))
        .ToList();
    Console.WriteLine("*** distances ***");
    distances.ForEach(d => Console.WriteLine(d));
    Console.WriteLine();

    var result = list1.Zip(list2)
       .Select(pointPair => (
            pointPair.First.Name,
            pointPair.Second.Name,
            pointPair.First.Distance(pointPair.Second)          
        ))
       .ToList();
    
    Console.WriteLine("*** distances (as triple) ***");
    result.ForEach(r => Console.WriteLine(r));
    Console.WriteLine();

    Console.WriteLine("*** distances (deconstruct triple) ***");
    foreach (var (name1, name2, distance) in result)
    {
        Console.WriteLine($"distance [{name1}-{name2}] = {distance:0.000}");
    }
    Console.WriteLine();

    var result2 = list1.Zip(list2)
      .Select(pointPair => (
           Name1: pointPair.First.Name,
           Name2: pointPair.Second.Name,
           Distance: pointPair.First.Distance(pointPair.Second)
       ))
      .ToList();
    Console.WriteLine("*** distances (as triple with named properties) ***");
    foreach (var res in result2)
    {
        Console.WriteLine($"distance [{res.Name1}-{res.Name2}] = {res.Distance:0.000}");
    }
    Console.WriteLine();
}

void DemoPolygonRandomPoints(int n)
{
    var rd = new Random(); // or a good distribution
    var points = Enumerable.Range(0, n)
        .Select(i => new Point2D
        {
            Name = $"P{i}",
            X = rd.NextDouble(),
            Y = rd.NextDouble()
        })
        .ToList();
    var polygon = new Polygon
    {
        Name = "Poly",
        Vertices = points
    };
    Console.WriteLine(polygon);
    Console.WriteLine(polygon.Perimeter);
    Console.WriteLine(polygon.Area);
}

DemoSubstitution();
DemoZip();
DemoForms();
DemoPolygonRandomPoints(5);




