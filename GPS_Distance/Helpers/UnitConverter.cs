using System;
using GPS_Distance.Models;

namespace GPS_Distance.Helpers
{
    public static partial class Helper
    {
        public static double DegreesToRadians(double degree) => degree * (Math.PI / 180);
        public static double RadiansToDegrees(double radian) => radian * (180 / Math.PI);

        public static double ConvertUnit(Unit unit, double distance) => unit switch
        {
            Unit.Metres => distance,
            Unit.Kilometres => distance / 1000,
            Unit.Miles => distance / 1609.344,
            _ => -1 // NOTE: Error, miles or runtime exception?
        };
    }
}

/*
The international mile is _precisely_ equal to 1.609344 km (or 25146/15625 km as a fraction).
                                                           (~0,6213711922373339696174341844)
*/
