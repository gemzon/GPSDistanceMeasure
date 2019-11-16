using System;
using GPS_Distance.Models;

namespace GPS_Distance.MeasurementFormulas
{
    public static partial class MeasureFormula
    {
        public static double HaversineMeasure(MeasurementInputs startLocation, Location endLocation)
        {
            double dlat = endLocation.LatitudeRadians - startLocation.LatitudeRadians;
            double dlon = endLocation.LongitudeRadians - startLocation.LongitudeRadians;

            double squaredSinLat = Math.Sin(dlat / 2) * Math.Sin(dlat / 2);
            double squaredSinLon = Math.Sin(dlon / 2) * Math.Sin(dlon / 2);

            double squaredCos = Math.Cos(startLocation.LatitudeRadians) * Math.Cos(endLocation.LatitudeRadians);

            double squared = squaredSinLat + squaredSinLon * squaredCos;

            double distanceMetres = startLocation.EarthRadius * 2 * Math.Asin(Math.Sqrt(squared));

            return distanceMetres;
        }
    }
}
