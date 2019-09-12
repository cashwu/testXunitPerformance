using System.Reflection;
using Microsoft.Xunit.Performance;
using Microsoft.Xunit.Performance.Api;
using testXunitPerformance.Controllers;

namespace testPerformance
{
    class Program
    {
        /// <summary>
        ///     https://github.com/Microsoft/xunit-performance
        ///     https://www.cnblogs.com/cgzl/p/9591417.html
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            using (var harness = new XunitPerformanceHarness(args))
            {
                var location = Assembly.GetEntryAssembly().Location;
                harness.RunBenchmarks(location);
            }
        }
    }

    public class PTest
    {
        [Benchmark(InnerIterationCount = 100)]
        public void P()
        {
            foreach (var iteration in Benchmark.Iterations)
            {
                var ctl = new ValuesController();

                using (iteration.StartMeasurement())
                {
                    var actionResult = ctl.Get();
                }
            }
        }
    }
}