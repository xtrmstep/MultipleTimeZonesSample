using System;

namespace MultipleTimeZonesSample.Console.Examples.Scheduling
{
    public class Scheduling_withDateTimeOffset
    {
        public static void Run()
        {
            var londonTimezone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var scheduledTime = new DateTimeOffset(new DateTime(2017, 3, 25, 10, 30, 0), TimeSpan.FromHours(0)); // non DST time
            var nextTime = scheduledTime.AddDays(1); // rescheduling event for the same future time
            var restored = TimeZoneInfo.ConvertTime(nextTime, londonTimezone); // DST time
            System.Console.WriteLine(scheduledTime);
            System.Console.WriteLine(restored);
        }
    }
}