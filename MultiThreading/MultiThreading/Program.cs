// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// main thread
// common data: 1M integers (long)
var data = Enumerable.Range(1, 1_000_000)
    .Select(i => (long)i)
    .ToArray();
// buffer to store results
int nChunk = 4; // number of jobs
int chunk = data.Length / nChunk;
var allRes = new long[4];

// restrict ThreadPool to 3 threads
var okMin = ThreadPool.SetMinThreads(3, 1000);
var okMax = ThreadPool.SetMaxThreads(3, 1000);
Console.WriteLine($"Change nb of threads: {okMin}, {okMax}");


// job to run in //
// NB: data, allRes and e are visible for the anonymous function
//      add these as args if you have a classic method
Action<(int, int, int, CountdownEvent)> action = (args) =>
{
    var (iFirst, iLast, n, e) = args;
    Console.WriteLine($"Job {n} started");
    long res = 0L;
    for (int i = iFirst; i < iLast; i++)
    {
        res += data[i];
    }
    allRes[n] = res;
    Thread.Sleep(2000); // too fast => slow down a little
    // Synchronization => signal job finished
    e.Signal();
};

// Thread synchronization with an event counter
using (CountdownEvent e = new CountdownEvent(nChunk))
{

    // start all jobs
    for (int n = 0; n < 4; n++)
    {
        ThreadPool.QueueUserWorkItem(action, (n * chunk, (n + 1) * chunk, n, e), true);
    }
    Console.WriteLine("All jobs started...");
    // Join: wait for CountDownEvent e to be 0
    e.Wait();
    Console.WriteLine("All jobs finished");
} // dispose CoundownEvent

Console.WriteLine($"Results from each job:");
foreach (var res in allRes)
{
    Console.WriteLine("- partial result: {0}", res);
}
var sum1 = allRes.Sum();
Console.WriteLine("Global result (threadpool): {0}", sum1);

// PLinQ
// https://learn.microsoft.com/fr-fr/dotnet/standard/parallel-programming/introduction-to-plinq

var sum2 = data.AsParallel().Sum();
var sum3 = data.Sum();

Console.WriteLine("Global result (PLinQ): {0}", sum2);
Console.WriteLine("Global result (LinQ): {0}", sum3);

