using System;
using GPS_Distance.Models;

namespace GPS_Distance.Helpers
{
    public static partial class Helper
    {
        public static double FormatDouble(double result) => Math.Round(result, 4);
        public static double ToUnit(this double value, Unit unit = Unit.Miles, int digits = 4) => Math.Round(ConvertUnit(unit, value), digits);
    }
}
