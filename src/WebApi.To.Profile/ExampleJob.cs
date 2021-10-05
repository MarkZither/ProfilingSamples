using System;
using System.Net;
using System.Threading.Tasks;

using Quartz;

using StackExchange.Profiling;

namespace WebApi.To.Profile
{
    internal class ExampleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var profiler = MiniProfiler.StartNew("My Profiler Name");
            using (profiler.Step("Short Work"))
            {
                Console.WriteLine("Short Work");
            }
            using (profiler.Step("Main Work"))
            {
                Console.WriteLine("Main Work");
                ClassLib.To.Test.Profiling.Class1 class1 = new ClassLib.To.Test.Profiling.Class1();
                int pointless = class1.LongRunningCalc();
            }
            using (profiler.CustomTiming("http", "GET Long timing"))
            {
                ClassLib.To.Test.Profiling.Class1 class1 = new ClassLib.To.Test.Profiling.Class1();
                int pointless = class1.LongRunningCalc();
            }
            using (profiler.Step("Last Work"))
            {
                Console.WriteLine("Last Work");
            }
            profiler.Stop();

            var url = "https://google.com";
            using (MiniProfiler.Current.CustomTiming("http", "GET " + url))
            {
                var client = new WebClient();
                var reply = client.DownloadString(url);
                ClassLib.To.Test.Profiling.Class1 class1 = new ClassLib.To.Test.Profiling.Class1();
                int pointless = class1.LongRunningCalc();
            }
            using (MiniProfiler.Current.Step("ExampleJobExecute"))
            {
                ClassLib.To.Test.Profiling.Class1 class1 = new ClassLib.To.Test.Profiling.Class1();
                int pointless = class1.LongRunningCalc();
                Console.WriteLine("Quartz!!!");
                return Task.CompletedTask;
            }
        }
    }
}