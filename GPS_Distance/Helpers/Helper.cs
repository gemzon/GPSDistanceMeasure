using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace GPS_Distance.Helpers
{
    public static class Helper // General helper class.
    {
        private static readonly string latitudePattern = @"^(?:\+|-)?(?:90(?:(?:(?:\.|,)0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:(?:\.|,)[0-9]{1,6})?))$";
        private static readonly string longitudePattern = @"^(?:\+|-)?(?:180(?:(?:(?:\.|,)0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:(?:\.|,)[0-9]{1,6})?))$";

        public static bool TryParseLatitude(string input, out double latitude)
            => TryParseRegexToDouble(input, latitudePattern, out latitude);

        public static bool TryParseLongitude(string input, out double longitude)
            => TryParseRegexToDouble(input, longitudePattern, out longitude);

        private static bool TryParseRegexToDouble(string input, string regex, out double value)
        {
            var valid = !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, regex);
            value = valid ? double.Parse(input.Replace(',', '.'), NumberFormatInfo.InvariantInfo) : 0;
            return valid;
        }

        public static double FormatDouble(double result) => Math.Round(result, 4);
    }
}
