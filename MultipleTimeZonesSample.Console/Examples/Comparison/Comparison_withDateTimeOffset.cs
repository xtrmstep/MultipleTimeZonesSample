using System;

namespace MultipleTimeZonesSample.Console.Examples.Comparison
{
    public class Comparison_withDateTimeOffset
    {
        public static void Run()
        {
            var originalUtc = new DateTimeOffset(new DateTime(2017, 1, 14, 1, 30, 0),TimeSpan.FromHours(0));
            var newYorkTimezone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var newYorkTime = TimeZoneInfo.ConvertTime(originalUtc, newYorkTimezone);

            System.Console.WriteLine(originalUtc == newYorkTime); // False, but should be True since the same moment in time

        }
    }
}