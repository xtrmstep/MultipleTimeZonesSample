using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleTimeZonesSample.Console.Examples.Comparison;
using MultipleTimeZonesSample.Console.Examples.Dst;
using MultipleTimeZonesSample.Console.Examples.Parsing;
using MultipleTimeZonesSample.Console.Examples.Scheduling;
using MultipleTimeZonesSample.Console.Examples.TimeZone;

namespace MultipleTimeZonesSample.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dst_SpringForward_withDateTimeOffset.Run();
            System.Console.ReadKey();
            
        }
    }
}
