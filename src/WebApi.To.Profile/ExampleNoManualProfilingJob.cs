using System;
using System.Net;
using System.Threading.Tasks;

using Quartz;

using StackExchange.Profiling;

namespace WebApi.To.Profile
{
    internal class ExampleNoManualProfilingJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var profiler = MiniProfiler.StartNew("My PostSharp MiniProfiler Magic");
            
            BasicPointlessClass basic = new BasicPointlessClass();
            int pointless = basic.WaitABit();

            profiler.Stop();

            return Task.CompletedTask;
        }
    }
}