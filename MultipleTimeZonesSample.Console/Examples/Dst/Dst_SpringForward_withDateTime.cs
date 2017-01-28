using System;
using System.Collections.Generic;

namespace MultipleTimeZonesSample.Console.Examples.Dst
{
    public class Dst_SpringForward_withDateTime
    {
        public static void Run()
        {
            var londonTimezone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var events = new Dictionary<DateTime, int>();
            var startUtcPeriod = new DateTime(2017, 3, 25, 23, 0, 0);
            var finishUtcPeriod = new DateTime(2017, 3, 26, 3, 0, 0);
            const int step = 10; // minutes

            var current = startUtcPeriod;
            while (current < finishUtcPeriod)
            {
                var londonTime = TimeZoneInfo.ConvertTimeFromUtc(current, londonTimezone);

                if (!events.ContainsKey(londonTime))
                    events.Add(londonTime, 0);
                events[londonTime] += 1;
                current = current.AddMinutes(step);
            }

            current = startUtcPeriod;
            while (current < finishUtcPeriod)
            {
                var value = "-";
                if (events.ContainsKey(current))
                    value = events[current].ToString();
                System.Console.WriteLine("{0:s}: {1}", current, value);
                current = current.AddMinutes(step);
            }
        }
    }
}