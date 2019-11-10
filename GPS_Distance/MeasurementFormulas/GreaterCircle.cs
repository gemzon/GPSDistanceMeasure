using GPS_Distance.Helpers;
using GPS_Distance.Models;
using System;

namespace GPS_Distance.MeasurementFormulas
{
    public static class GreaterCircle
    {
        public static double Measure(Location startLocation, Location endLocation, double radius)
        {     
            double sineAngle = Math.Sin(startLocation.LatitudeRadians) * Math.Sin(endLocation.LatitudeRadians);

            double cosAngle = Math.Cos(startLocation.LatitudeRadians) * Math.Cos(endLocation.LatitudeRadians)
                            * Math.Cos(endLocation.LongitudeRadians - startLocation.LongitudeRadians);

            double distanceMetres = radius * Math.Acos(sineAngle + cosAngle);

            return  distanceMetres;
        }
    }
}