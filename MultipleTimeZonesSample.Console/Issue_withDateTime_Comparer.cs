using System;

namespace MultipleTimeZonesSample.Console
{
    public class Issue_withDateTime_Comparer
    {
        public static void Run()
        {
            var originalUtc = new DateTime(2017, 1, 14, 1, 30, 0, DateTimeKind.Utc);
            var newYorkTimezone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var newYorkTime = TimeZoneInfo.ConvertTimeFromUtc(originalUtc, newYorkTimezone);
            var newUtc = new DateTime(newYorkTime.Year, newYorkTime.Month, newYorkTime.Day, newYorkTime.Hour, newYorkTime.Minute, newYorkTime.Second, DateTimeKind.Utc);

            System.Console.WriteLine(newYorkTime == newUtc); // True

        }
    }
}