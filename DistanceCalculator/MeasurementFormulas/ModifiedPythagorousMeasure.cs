using System;
using DistanceCalculator.Models;

namespace DistanceCalculator.MeasurementFormulas
{
    public static partial class MeasureFormula
    {
        public static double ModifiedPythagorasMeasure(Location startlocation, Location endLocation)
        {
            double lat = endLocation.Latitude - startlocation.Latitude;
            double lon = endLocation.Longitude - startlocation.Longitude;

            double squaredLat = Math.Pow(69.1 * lat, 2);
            double squaredLon = Math.Pow(53.0 * lon, 2);

            var distanceMetres = Math.Sqrt(squaredLat + squaredLon);

            return distanceMetres;
        }
    }
}