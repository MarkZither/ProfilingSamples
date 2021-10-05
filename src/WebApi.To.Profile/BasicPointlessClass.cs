using System.Threading;

namespace WebApi.To.Profile
{
    public class BasicPointlessClass
    {
        public int WaitABit()
        {
            Thread.Sleep(1000);
            ClassLib.To.Test.Profiling.Class1 class1 = new ClassLib.To.Test.Profiling.Class1();
            int pointless = class1.LongRunningCalc();
            return 20;
        }
    }
}
