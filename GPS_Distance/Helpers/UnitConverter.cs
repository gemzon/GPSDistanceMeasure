using GPS_Distance.Models;
using System;

namespace GPS_Distance.Helpers
{
    public static class UnitConverter
    {
        public static double DegreesToRadians(double degree)
        {
            return degree * (Math.PI / 180);
        }

        public static double RadiansToDegrees(double radian)
        {
          
            return (Math.PI / radian) * (180 / Math.PI);
        }

        public static double ConvertUnit(Unit unit ,double distance)
        {
            switch (unit)
            {
                case Unit.Metres:
                    return distance;
                case Unit.Kilometres:
                    return distance / 1000;
                default:
                    return distance * 0.00062137;
            }
           
        }
}
}