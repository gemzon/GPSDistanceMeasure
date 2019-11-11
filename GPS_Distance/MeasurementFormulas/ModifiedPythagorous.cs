using System;
using GPS_Distance.Models;

namespace GPS_Distance.MeasurementFormulas
{
    public static class ModifiedPythagoras
    {
        public static double Measure(Location startlocation, Location endLocation)
        {
            double dlat = endLocation.Latitude - startlocation.Latitude;
            double dlon = endLocation.Longitude - startlocation.Longitude;

            double squaredLat = Math.Pow(69.1 * dlat, 2);
            double squaredLon = Math.Pow(53.0 * dlon, 2);

            var distanceMetres = Math.Sqrt(squaredLat + squaredLon);

            return  distanceMetres;
        }
    }
}
