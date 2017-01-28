using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleTimeZonesSample.Console.Examples.Comparison;
using MultipleTimeZonesSample.Console.Examples.Dst;

namespace MultipleTimeZonesSample.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Comparison_withDateTime.Run();
            System.Console.ReadKey();
            
        }
    }
}
