using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MultipleTimeZonesSample
{
    public class UtcTests
    {
        [Fact]
        public void Should_return_all_timezones()
        {
            var tz = TimeZoneInfo.GetSystemTimeZones();
            var sb = new StringBuilder();
            sb.AppendLine("Id;BaseUtcOffset;DaylightName;DisplayName;StandardName;SupportsDaylightSavingTime");
            foreach (var zoneInfo in tz)
            {
                sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5}",
                    zoneInfo.Id, 
                    zoneInfo.BaseUtcOffset, 
                    zoneInfo.DaylightName,
                    zoneInfo.DisplayName,
                    zoneInfo.StandardName,
                    zoneInfo.SupportsDaylightSavingTime));
            }
            var tzList = sb.ToString();
            // set a breakpoint here and take the value of the string
        }

        [Fact]
        public void Timezone_information_is_required_to_get_local_time()
        {
            var newYorkUtcTime = new DateTime(2017, 1, 14, 6, 30, 0);
            var newYorkTimezone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var newYorkLocalTime = TimeZoneInfo.ConvertTimeFromUtc(newYorkUtcTime, newYorkTimezone);
            
            Assert.Equal(new DateTime(2017, 1, 14, 1, 30, 0), newYorkLocalTime);
        }

        [Fact]
        public void Should_see_correct_local_time_from_different_timezone_2()
        {
            var losAngelesUtcTime = new DateTime(2017, 1, 14, 9, 30, 0);

            var losAngelesTimezone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var losAngelesLocalTime = TimeZoneInfo.ConvertTimeFromUtc(losAngelesUtcTime, losAngelesTimezone);

            Assert.Equal(new DateTime(2017, 1, 14, 1, 30, 0), losAngelesLocalTime);
        }
    }
}
