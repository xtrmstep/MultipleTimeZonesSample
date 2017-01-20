using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c = System.Console;

namespace MultipleTimeZonesSample.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Issue_withDateTime_Running_inDst_SprintForward_UserInput();
            //Issue_withDateTime_Running_inDst_SprintForward();
            Issue_withDateTime_Running_inDst_FallBack_UserInput();
            //Issue_withDateTime_Running_inDst_FallBack();
            System.Console.ReadKey();

        }

        private static void Issue_withDateTimeKind_Unspecified()
        {
            var original = new DateTime(2017, 1, 14, 1, 30, 0);
            c.WriteLine("User input:");
            c.WriteLine("Input:\t\t{0}", original);
            c.WriteLine("ISO 8601:\t{0:O}", original);
            c.WriteLine("RFC 1123:\t{0:R}", original);
            c.WriteLine("Sortable:\t{0:s}", original);
            c.WriteLine("UTC sortable:\t{0:u}", original);
            c.WriteLine("UTC full:\t{0:U}", original);

            c.WriteLine();

            var utc = original.ToUniversalTime();
            c.WriteLine("As UTC:");
            c.WriteLine("Input:\t\t{0}", utc);
            c.WriteLine("ISO 8601:\t{0:O}", utc);
            c.WriteLine("RFC 1123:\t{0:R}", utc);
            c.WriteLine("Sortable:\t{0:s}", utc);
            c.WriteLine("UTC sortable:\t{0:u}", utc);
            c.WriteLine("UTC full:\t{0:U}", utc);

            c.WriteLine();

            var local = original.ToLocalTime();
            c.WriteLine("As Local:");
            c.WriteLine("Input:\t\t{0}", local);
            c.WriteLine("ISO 8601:\t{0:O}", local);
            c.WriteLine("RFC 1123:\t{0:R}", local);
            c.WriteLine("Sortable:\t{0:s}", local);
            c.WriteLine("UTC sortable:\t{0:u}", local);
            c.WriteLine("UTC full:\t{0:U}", local);
        }

        private static void Issue_withDateTimeKind_notParsing()
        {
            var formaters = new Dictionary<string, string>
            {
                {"ISO 8601", "O"},
                {"RFC 1123", "R"},
                {"Sortable", "s"},
                {"UTC sortable", "u"},
                {"UTC full", "U"}
            };

            var original = new DateTime(2017, 1, 14, 1, 30, 0, DateTimeKind.Utc);
            foreach (var formater in formaters)
            {
                c.WriteLine(formater.Key);
                var dateString = original.ToString(formater.Value);
                var parsed = DateTime.Parse(dateString, null, DateTimeStyles.AdjustToUniversal);
                c.WriteLine("Original:\t{0}\tKind: {1}", original.ToString(formater.Value), original.Kind);
                c.WriteLine("Parsed:\t\t{0}\tKind: {1}", parsed.ToString(formater.Value), parsed.Kind);
            }
        }

        private static void Issue_withDateTime_Comparer()
        {
            var originalUtc = new DateTime(2017, 1, 14, 1, 30, 0, DateTimeKind.Utc);
            var newYorkTimezone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var newYorkTime = TimeZoneInfo.ConvertTimeFromUtc(originalUtc, newYorkTimezone);
            var newUtc = new DateTime(newYorkTime.Year, newYorkTime.Month, newYorkTime.Day, newYorkTime.Hour, newYorkTime.Minute, newYorkTime.Second, DateTimeKind.Utc);

            c.WriteLine(newYorkTime == newUtc); // True

        }

        private static void Issue_withDateTime_Scheduling_inFuture()
        {
            var springForward = new DateTime(2017, 3, 26, 1, 0, 0); // there is no such time for GMT (from 1 to 1:59)
            var fallBackward = new DateTime(2017, 10, 29, 2, 0, 0); // this time will happen twice in GMT (from 1 to 1:59)

            var londonTimezone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var scheduledTime = new DateTime(2017, 3, 25, 10, 30, 0, DateTimeKind.Utc); // non DST time
            var utcScheduledTime = TimeZoneInfo.ConvertTimeToUtc(scheduledTime);
            utcScheduledTime = utcScheduledTime.AddDays(1); // rescheduling event for the same future time
            var restored = TimeZoneInfo.ConvertTimeFromUtc(utcScheduledTime, londonTimezone); // DST time
            c.WriteLine(scheduledTime);
            c.WriteLine(restored);
        }

        private static void Issue_withDateTime_Running_inDst_SprintForward()
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
                c.WriteLine("{0:s}: {1}", current, value);
                current = current.AddMinutes(step);
            }
        }

        private static void Issue_withDateTime_Running_inDst_SprintForward_UserInput()
        {
            var userInput = new[]
            {
                new DateTime(2017, 3, 25, 23, 0, 0),
                new DateTime(2017, 3, 25, 23, 10, 0),
                new DateTime(2017, 3, 25, 23, 20, 0),
                new DateTime(2017, 3, 25, 23, 30, 0),
                new DateTime(2017, 3, 25, 23, 40, 0),
                new DateTime(2017, 3, 25, 23, 50, 0),
                new DateTime(2017, 3, 26, 0, 0, 0),
                new DateTime(2017, 3, 26, 0, 10, 0),
                new DateTime(2017, 3, 26, 0, 20, 0),
                new DateTime(2017, 3, 26, 0, 30, 0),
                new DateTime(2017, 3, 26, 0, 40, 0),
                new DateTime(2017, 3, 26, 0, 50, 0),
                // DST sprint forward + 1
                new DateTime(2017, 3, 26, 2, 00, 0),
                new DateTime(2017, 3, 26, 2, 10, 0),
                new DateTime(2017, 3, 26, 2, 20, 0),
                new DateTime(2017, 3, 26, 2, 30, 0),
                new DateTime(2017, 3, 26, 2, 40, 0),
                new DateTime(2017, 3, 26, 2, 50, 0),
                new DateTime(2017, 3, 26, 3, 00, 0),
                new DateTime(2017, 3, 26, 3, 10, 0),
                new DateTime(2017, 3, 26, 3, 20, 0),
                new DateTime(2017, 3, 26, 3, 30, 0),
                new DateTime(2017, 3, 26, 3, 40, 0),
                new DateTime(2017, 3, 26, 3, 50, 0)
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

            foreach (var dateTime in userInput)
            {
                var value = "-";
                if (eventsInUtc.ContainsKey(dateTime))
                    value = eventsInUtc[dateTime].ToString();
                c.WriteLine("{0:s}: {1}", dateTime, value);
            }
        }

        private static void Issue_withDateTime_Running_inDst_FallBack()
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
                c.WriteLine("{0:s}: {1}", current, value);
                current = current.AddMinutes(step);
            }
        }

        private static void Issue_withDateTime_Running_inDst_FallBack_UserInput()
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
                c.WriteLine("{0:s}: {1}", dateTime.Key, dateTime.Value);
        }
    }
}
