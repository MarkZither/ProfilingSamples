using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClassLib.To.Test.Profiling
{
    public class Class2
    {
        public int ShorterRunningCalc()
        {
            Thread.Sleep(2000);
            return 10;
        }
    }
}
