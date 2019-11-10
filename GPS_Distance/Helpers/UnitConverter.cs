using System;
using GPS_Distance.Models;

namespace GPS_Distance.Helpers
{
    public static class UnitConverter
    {
        public static double DegreesToRadians(double degree) => degree * (Math.PI / 180);
        public static double RadiansToDegrees(double radian) => radian * (180 / Math.PI);
        public static double ConvertUnit(Unit unit, double distance) => unit switch
        {
            Unit.Metres => distance,
            Unit.Kilometres => distance / 1000,
            Unit.Miles => distance * 0.00062137,
            _ => -1 // error
        };
    }
}

//return ((Math.PI / radian) * (180 / Math.PI)); (1)
//return Math.PI / radian * 180 / Math.PI;       (2)
