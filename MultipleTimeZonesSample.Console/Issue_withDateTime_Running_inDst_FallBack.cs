using System;
using System.Collections.Generic;

namespace MultipleTimeZonesSample.Console
{
    public class Issue_withDateTime_Running_inDst_FallBack
    {
        public static void Run()
        {
            var londonTimezone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var events = new Dictionary<DateTime, int>();
            var startUtcPeriod = new DateTime(2017, 10, 28, 23, 00, 0);
            var finishUtcPeriod = new DateTime(2017, 10, 29, 3, 0, 0);
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