using GPS_Distance.Helpers;
using GPS_Distance.Models;
using System;

namespace GPS_Distance.MeasurementFormulas
{
    public static class GreaterCircle
    {
        public static double Measure(Location startLocation, Location endLocation, double radius)
        {     
            double sineAngle = Math.Sin(startLocation.Latitude) * Math.Sin(endLocation.Latitude);
            double cosAngle = Math.Cos(startLocation.Latitude) * Math.Cos(endLocation.Latitude) *
                Math.Cos(endLocation.Longitude - startLocation.Longitude);

            double distanceMetres = radius * Math.Acos(sineAngle + cosAngle);

            return  distanceMetres;
        }
    }
}