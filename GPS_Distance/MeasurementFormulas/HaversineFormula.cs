using System;
using GPS_Distance.Models;

namespace GPS_Distance.MeasurementFormulas
{
    public static class HaversineFormula
    {
        public static double Measure(MeasurementInputs startLocation, Location endLocation)
        {
            double dlat = endLocation.Latitude - startLocation.Latitude;
            double dlon = endLocation.Longitude - startLocation.Longitude;

            double squaredSinLat = Math.Sin(dlat / 2) * Math.Sin(dlat / 2);
            double squaredSinLon = Math.Sin(dlon / 2) * Math.Sin(dlon / 2);

            double squaredCos = Math.Cos(startLocation.Latitude) * Math.Cos(endLocation.Latitude);

            double squared = squaredSinLat + squaredSinLon * squaredCos;

            double distanceMetres = startLocation.EarthRadius * 2 * Math.Asin(Math.Sqrt(squared));

            return distanceMetres;
        }
    }
}
