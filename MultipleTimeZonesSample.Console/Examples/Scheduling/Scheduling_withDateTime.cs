using System;

namespace MultipleTimeZonesSample.Console.Examples.Scheduling
{
    public class Scheduling_withDateTime
    {
        public static void Run()
        {
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