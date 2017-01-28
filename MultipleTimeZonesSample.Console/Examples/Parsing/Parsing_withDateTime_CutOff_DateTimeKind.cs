using System;
using System.Collections.Generic;
using System.Globalization;

namespace MultipleTimeZonesSample.Console.Examples.Parsing
{
    public class Parsing_withDateTime_CutOff_DateTimeKind
    {
        public static void Run()
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
                System.Console.WriteLine(formater.Key);
                var dateString = original.ToString(formater.Value);
                var parsed = DateTime.Parse(dateString, null, DateTimeStyles.AdjustToUniversal);
                System.Console.WriteLine("Original:\t{0}\tKind: {1}", original.ToString(formater.Value), original.Kind);
                System.Console.WriteLine("Parsed:\t\t{0}\tKind: {1}", parsed.ToString(formater.Value), parsed.Kind);
            }
        }
    }
}