using System;
using System.Collections.Generic;

namespace MultipleTimeZonesSample.Console.Examples.Dst
{
    public class Dst_SpringForward_withDateTimeOffset
    {
        // there is no such time for GMT (from 1 to 1:59)
        private static DateTime _springForward = new DateTime(2017, 3, 26, 1, 0, 0);

        public static void Run()
        {
            var userInput = new[]
            {
                new DateTimeOffset(new DateTime(2017, 3, 25, 23, 0, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 25, 23, 10, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 25, 23, 20, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 25, 23, 30, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 25, 23, 40, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 25, 23, 50, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 0, 0, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 0, 10, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 0, 20, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 0, 30, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 0, 40, 0), TimeSpan.FromHours(0)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 0, 50, 0), TimeSpan.FromHours(0)),
                // DST sprint forward + 1
                new DateTimeOffset(new DateTime(2017, 3, 26, 2, 00, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 2, 10, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 2, 20, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 2, 30, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 2, 40, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 2, 50, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 3, 00, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 3, 10, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 3, 20, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 3, 30, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 3, 40, 0), TimeSpan.FromHours(1)),
                new DateTimeOffset(new DateTime(2017, 3, 26, 3, 50, 0), TimeSpan.FromHours(1))
            };
            var londonTimezone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var eventsInUtc = new Dictionary<DateTimeOffset, int>();
            foreach (var dateTime in userInput)
            {
                var utcTime = TimeZoneInfo.ConvertTime(dateTime.DateTime, londonTimezone, TimeZoneInfo.Utc);
                if (!eventsInUtc.ContainsKey(utcTime))
                    eventsInUtc.Add(utcTime, 0);
                eventsInUtc[utcTime] += 1;
            }

            foreach (var pair in eventsInUtc)
            {
                System.Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }

    }
}