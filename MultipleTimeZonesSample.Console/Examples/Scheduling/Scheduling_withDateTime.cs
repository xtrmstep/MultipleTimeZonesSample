using System;

namespace MultipleTimeZonesSample.Console.Examples.Scheduling
{
    public class Scheduling_withDateTime
    {

        public static void Run()
        {
            var springForward = new DateTime(2017, 3, 26, 1, 0, 0); // there is no such time for GMT (from 1 to 1:59)
            var fallBackward = new DateTime(2017, 10, 29, 2, 0, 0); // this time will happen twice in GMT (from 1 to 1:59)

            var londonTimezone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var scheduledTime = new DateTime(2017, 3, 25, 10, 30, 0, DateTimeKind.Utc); // non DST time
            var utcScheduledTime = TimeZoneInfo.ConvertTimeToUtc(scheduledTime);
            utcScheduledTime = utcScheduledTime.AddDays(1); // rescheduling event for the same future time
            var restored = TimeZoneInfo.ConvertTimeFromUtc(utcScheduledTime, londonTimezone); // DST time
            System.Console.WriteLine(scheduledTime);
            System.Console.WriteLine(restored);
        }
    }
}