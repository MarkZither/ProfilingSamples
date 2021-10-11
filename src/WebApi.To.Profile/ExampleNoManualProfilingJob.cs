using System;
using System.Net;
using System.Threading.Tasks;

using Quartz;

using StackExchange.Profiling;

namespace WebApi.To.Profile
{
    internal class ExampleNoManualProfilingJob : IJob
    {
        private readonly IBasicPointlessClass _basicPointlessClass;
        public ExampleNoManualProfilingJob(IBasicPointlessClass basicPointlessClass)
        {
            _basicPointlessClass = basicPointlessClass;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var profiler = MiniProfiler.StartNew("My PostSharp MiniProfiler Magic");
            
            int pointless = _basicPointlessClass.WaitABit();

            profiler.Stop();

            return Task.CompletedTask;
        }
    }
}