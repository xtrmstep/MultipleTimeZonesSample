using System;
using System.Collections.Generic;

namespace MultipleTimeZonesSample.Console.Examples.Dst
{
    public class Dst_FallBack_withDateTime
    {
        // this time will happen twice in GMT (from 1 to 1:59)
        private static DateTime _fallBackward = new DateTime(2017, 10, 29, 2, 0, 0);

        public static void Run()
        {
            var userInput = new[]
            {
                new DateTime(2017, 10, 28, 23, 00, 0),
                new DateTime(2017, 10, 28, 23, 10, 0),
                new DateTime(2017, 10, 28, 23, 20, 0),
                new DateTime(2017, 10, 28, 23, 30, 0),
                new DateTime(2017, 10, 28, 23, 40, 0),
                new DateTime(2017, 10, 28, 23, 50, 0),
                new DateTime(2017, 10, 29, 0, 00, 0),
                new DateTime(2017, 10, 29, 0, 10, 0),
                new DateTime(2017, 10, 29, 0, 20, 0),
                new DateTime(2017, 10, 29, 0, 30, 0),
                new DateTime(2017, 10, 29, 0, 40, 0),
                new DateTime(2017, 10, 29, 0, 50, 0),
                new DateTime(2017, 10, 29, 1, 00, 0),
                new DateTime(2017, 10, 29, 1, 10, 0),
                new DateTime(2017, 10, 29, 1, 20, 0),
                new DateTime(2017, 10, 29, 1, 30, 0),
                new DateTime(2017, 10, 29, 1, 40, 0),
                new DateTime(2017, 10, 29, 1, 50, 0),
                // DST fall back -1
                new DateTime(2017, 10, 29, 1, 00, 0),
                new DateTime(2017, 10, 29, 1, 10, 0),
                new DateTime(2017, 10, 29, 1, 20, 0),
                new DateTime(2017, 10, 29, 1, 30, 0),
                new DateTime(2017, 10, 29, 1, 40, 0),
                new DateTime(2017, 10, 29, 1, 50, 0),
                new DateTime(2017, 10, 29, 2, 00, 0),
                new DateTime(2017, 10, 29, 2, 10, 0),
                new DateTime(2017, 10, 29, 2, 20, 0),
                new DateTime(2017, 10, 29, 2, 30, 0),
                new DateTime(2017, 10, 29, 2, 40, 0),
                new DateTime(2017, 10, 29, 2, 50, 0),
            };
            var londonTimezone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var eventsInUtc = new Dictionary<DateTime, int>();
            foreach (var dateTime in userInput)
            {
                var utcTime = TimeZoneInfo.ConvertTimeToUtc(dateTime, londonTimezone);
                if (!eventsInUtc.ContainsKey(utcTime))
                    eventsInUtc.Add(utcTime, 0);
                eventsInUtc[utcTime] += 1;
            }

            foreach (var dateTime in eventsInUtc)
                System.Console.WriteLine("{0:s}: {1}", dateTime.Key, dateTime.Value);
        }
    }
}