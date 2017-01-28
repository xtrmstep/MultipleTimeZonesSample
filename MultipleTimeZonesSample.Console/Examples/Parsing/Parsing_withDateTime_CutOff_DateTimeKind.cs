using System;
using System.Collections.Generic;
using System.Globalization;

namespace MultipleTimeZonesSample.Console.Examples.Parsing
{
    public class Parsing_withDateTime_CutOff_DateTimeKind
    {
        public static void Run()
        {
            var original = new DateTime(2017, 1, 14, 1, 30, 0, DateTimeKind.Utc);
            System.Console.WriteLine("Sortable: " + original.ToString("s"));
            System.Console.WriteLine("ISO 8601: " + original.ToString("O"));
            System.Console.WriteLine("Zulu time: " + original.ToString("u"));
            System.Console.WriteLine("Unit time: " + original.Ticks);

            System.Console.WriteLine("");

            var parsed = DateTime.Parse("2017-01-14T01:30:00", null, DateTimeStyles.AdjustToUniversal);
            System.Console.WriteLine("Parsed: {0:s} Kind: {1}", parsed, parsed.Kind);

            parsed = DateTime.Parse("2017-01-14T01:30:00.0000000Z", null, DateTimeStyles.AdjustToUniversal);
            System.Console.WriteLine("Parsed: {0:s} Kind: {1}", parsed, parsed.Kind);

            parsed = DateTime.Parse("2017-01-14 01:30:00Z", null, DateTimeStyles.AdjustToUniversal);
            System.Console.WriteLine("Parsed: {0:s} Kind: {1}", parsed, parsed.Kind);

            parsed = DateTime.FromFileTimeUtc(long.Parse("636199542000000000"));
            System.Console.WriteLine("Parsed: {0:s} Kind: {1}", parsed, parsed.Kind);
        }
    }
}