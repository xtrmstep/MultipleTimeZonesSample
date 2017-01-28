using System;

namespace MultipleTimeZonesSample.Console.Examples.Comparison
{
    public class Comparison_withDateTime
    {
        public static void Run()
        {
            var originalUtc = new DateTime(2017, 1, 14, 1, 30, 0, DateTimeKind.Utc);
            var newYorkTimezone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var newYorkTime = TimeZoneInfo.ConvertTimeFromUtc(originalUtc, newYorkTimezone);

            System.Console.WriteLine(originalUtc == newYorkTime); // False, but should be True since the same moment in time

        }
    }
}