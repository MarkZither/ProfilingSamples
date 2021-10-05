using System;
using System.Threading;

namespace ClassLib.To.Test.Profiling
{
    public class Class1
    {
        public int LongRunningCalc()
        {
            Thread.Sleep(10000);
            Class2 class2 = new Class2();
            class2.ShorterRunningCalc();
            return 10;
        }
    }
}
