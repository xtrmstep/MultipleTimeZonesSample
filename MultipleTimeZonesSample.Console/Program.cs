using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c = System.Console;

namespace MultipleTimeZonesSample.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var original = new DateTime(2017, 1, 14, 1, 30, 0, DateTimeKind.Utc);
            c.WriteLine("User input:");
            c.WriteLine("Input:\t\t{0}", original);
            c.WriteLine("ISO 8601:\t{0:O}", original);
            c.WriteLine("RFC 1123:\t{0:R}", original);
            c.WriteLine("Sortable:\t{0:s}", original);
            c.WriteLine("UTC sortable:\t{0:u}", original);
            c.WriteLine("UTC full:\t{0:U}", original);

            c.WriteLine();

            var utc = original.ToUniversalTime();
            c.WriteLine("As UTC:");
            c.WriteLine("Input:\t\t{0}", utc);
            c.WriteLine("ISO 8601:\t{0:O}", utc);
            c.WriteLine("RFC 1123:\t{0:R}", utc);
            c.WriteLine("Sortable:\t{0:s}", utc);
            c.WriteLine("UTC sortable:\t{0:u}", utc);
            c.WriteLine("UTC full:\t{0:U}", utc);

            c.WriteLine();

            var local = original.ToLocalTime();
            c.WriteLine("As Local:");
            c.WriteLine("Input:\t\t{0}", local);
            c.WriteLine("ISO 8601:\t{0:O}", local);
            c.WriteLine("RFC 1123:\t{0:R}", local);
            c.WriteLine("Sortable:\t{0:s}", local);
            c.WriteLine("UTC sortable:\t{0:u}", local);
            c.WriteLine("UTC full:\t{0:U}", local);



            //var userInput1 = new DateTime(2017, 1, 14, 1, 30, 0, DateTimeKind.Utc);
            //var utcTime1 = userInput.ToUniversalTime();

            //System.Console.WriteLine(userInput.ToString("u"));
            //System.Console.WriteLine(utcTime.ToString("u"));
            //System.Console.WriteLine(userInput1.ToString("u"));
            //System.Console.WriteLine(utcTime1.ToString("u"));
            System.Console.ReadKey();
        }
    }
}
