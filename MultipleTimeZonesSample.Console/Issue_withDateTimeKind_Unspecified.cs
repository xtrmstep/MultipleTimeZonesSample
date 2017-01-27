using System;

namespace MultipleTimeZonesSample.Console
{
    public class Issue_withDateTimeKind_Unspecified
    {
        public static void Run()
        {
            var original = new DateTime(2017, 1, 14, 1, 30, 0);
            System.Console.WriteLine("User input:");
            System.Console.WriteLine("Input:\t\t{0}", original);
            System.Console.WriteLine("ISO 8601:\t{0:O}", original);
            System.Console.WriteLine("RFC 1123:\t{0:R}", original);
            System.Console.WriteLine("Sortable:\t{0:s}", original);
            System.Console.WriteLine("UTC sortable:\t{0:u}", original);
            System.Console.WriteLine("UTC full:\t{0:U}", original);

            System.Console.WriteLine();

            var utc = original.ToUniversalTime();
            System.Console.WriteLine("As UTC:");
            System.Console.WriteLine("Input:\t\t{0}", utc);
            System.Console.WriteLine("ISO 8601:\t{0:O}", utc);
            System.Console.WriteLine("RFC 1123:\t{0:R}", utc);
            System.Console.WriteLine("Sortable:\t{0:s}", utc);
            System.Console.WriteLine("UTC sortable:\t{0:u}", utc);
            System.Console.WriteLine("UTC full:\t{0:U}", utc);

            System.Console.WriteLine();

            var local = original.ToLocalTime();
            System.Console.WriteLine("As Local:");
            System.Console.WriteLine("Input:\t\t{0}", local);
            System.Console.WriteLine("ISO 8601:\t{0:O}", local);
            System.Console.WriteLine("RFC 1123:\t{0:R}", local);
            System.Console.WriteLine("Sortable:\t{0:s}", local);
            System.Console.WriteLine("UTC sortable:\t{0:u}", local);
            System.Console.WriteLine("UTC full:\t{0:U}", local);
        }
    }
}