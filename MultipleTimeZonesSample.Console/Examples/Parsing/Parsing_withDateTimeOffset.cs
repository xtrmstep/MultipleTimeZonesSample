using System;
using System.Collections.Generic;
using System.Globalization;

namespace MultipleTimeZonesSample.Console.Examples.Parsing
{
    public class Parsing_withDateTimeOffset
    {
        public static void Run()
        {
            var original = new DateTimeOffset(new DateTime(2017, 1, 14, 1, 30, 0), TimeSpan.FromHours(2)).ToUniversalTime();
            System.Console.WriteLine("Sortable: " + original.ToString("s"));
            System.Console.WriteLine("ISO 8601: " + original.ToString("O"));
            System.Console.WriteLine("Zulu time: " + original.ToString("u"));
            System.Console.WriteLine("Unix time: " + original.ToUnixTimeMilliseconds());

            System.Console.WriteLine("");

            var parsed = DateTimeOffset.Parse("2017-01-14T01:30:00 +02:00").ToUniversalTime();
            System.Console.WriteLine("Parsed: {0:O}", parsed);

            parsed = DateTimeOffset.Parse("2017-01-14T01:30:00.0000000+02:00").ToUniversalTime();
            System.Console.WriteLine("Parsed: {0:O}", parsed);

            parsed = DateTimeOffset.Parse("2017-01-14 01:30:00 +02:00").ToUniversalTime();
            System.Console.WriteLine("Parsed: {0:O}", parsed);

            parsed = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse("1484350200000")).ToUniversalTime();
            System.Console.WriteLine("Parsed: {0:O}", parsed);
        }
    }
}