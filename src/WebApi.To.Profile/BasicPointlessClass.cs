using System.Linq;
using System.Threading;

using WebApi.To.Profile.Services;

namespace WebApi.To.Profile
{
    public class BasicPointlessClass : IBasicPointlessClass
    {
        private readonly IBloggingService _bloggingService;
        public BasicPointlessClass(IBloggingService bloggingService)
        {
            _bloggingService = bloggingService;
        }
        public int WaitABit()
        {
            var blogs = _bloggingService.GetBlogs();
            int blogsCount = blogs.Count();
            Thread.Sleep(1000);
            ClassLib.To.Test.Profiling.Class1 class1 = new ClassLib.To.Test.Profiling.Class1();
            int pointless = class1.LongRunningCalc();
            return 20;
        }
    }
}
