using System;
using System.Collections.Generic;
using System.Text;

namespace GPS_Distance
{
    public static class UnitConverter
    {
        public static double DegreesToRadians(double degree)
        {
           return (degree * Math.PI/180);
        }
        public static double RadiansToDegrees(double radian)
        {
            return (Math.PI / radian * 180 / Math.PI);
        }
    }
}
