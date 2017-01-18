using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c = System.Console;

namespace MultipleTimeZonesSample.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Issue_withDateTime_Comparer();
            System.Console.ReadKey();

        }

        private static void Issue_withDateTimeKind_Unspecified()
        {
            var original = new DateTime(2017, 1, 14, 1, 30, 0);
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
        }

        private static void Issue_withDateTimeKind_notParsing()
        {
            var formaters = new Dictionary<string, string>
            {
                {"ISO 8601", "O"},
                {"RFC 1123", "R"},
                {"Sortable", "s"},
                {"UTC sortable", "u"},
                {"UTC full", "U"}
            };

            var original = new DateTime(2017, 1, 14, 1, 30, 0, DateTimeKind.Utc);
            foreach (var formater in formaters)
            {
                c.WriteLine(formater.Key);
                var dateString = original.ToString(formater.Value);
                var parsed = DateTime.Parse(dateString, null, DateTimeStyles.AdjustToUniversal);
                c.WriteLine("Original:\t{0}\tKind: {1}", original.ToString(formater.Value), original.Kind);
                c.WriteLine("Parsed:\t\t{0}\tKind: {1}", parsed.ToString(formater.Value), parsed.Kind);
            }
        }

        private static void Issue_withDateTime_Comparer()
        {
            var originalUtc = new DateTime(2017, 1, 14, 1, 30, 0, DateTimeKind.Utc);
            var newYorkTimezone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var newYorkTime = TimeZoneInfo.ConvertTimeFromUtc(originalUtc, newYorkTimezone);
            var newUtc = new DateTime(newYorkTime.Year, newYorkTime.Month, newYorkTime.Day, newYorkTime.Hour, newYorkTime.Minute, newYorkTime.Second, DateTimeKind.Utc);

            c.WriteLine(newYorkTime == newUtc); // True

        }
    }
}
