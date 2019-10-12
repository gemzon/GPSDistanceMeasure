using System;

namespace GPS_Distance.Helpers
{
    public static class UnitConverter
    {
        public static double DegreesToRadians(double degree)
        {
           return ( degree * (Math.PI/180));
        }
        public static double RadiansToDegrees(double radian)
        {
            //return ((Math.PI / radian) * (180 / Math.PI));
            return Math.PI/radian * 180/Math.PI;
        }

        public static double MetresToMiles(double metre)
        {
            return metre * 0.00062137;
        }
    }
}
