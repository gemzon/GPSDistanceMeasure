using GPS_Distance.Helpers;
using GPS_Distance.Models;
using System;

namespace GPS_Distance.MeasurementFormulas
{
    public static class HaversineFormula
    {
        public static double Measure(Location startLocation, Location endLocation, double radius, Unit unit)
        {
            double dlat = endLocation.Latitude - startLocation.Latitude;

            double dlon = endLocation.Longitude - startLocation.Longitude;

            double squaredSinDlat = Math.Sin(dlat / 2) * Math.Sin(dlat / 2);

            double squaredSinLon = Math.Sin(dlon / 2) * Math.Sin(dlon / 2);

            double squaredCos = Math.Cos(startLocation.Latitude) * Math.Cos(endLocation.Latitude);

            double squared = squaredSinDlat + squaredSinLon * squaredCos;
            double distanceMetres = radius * 2 * Math.Asin(Math.Sqrt(squared));

            if (unit == Unit.Metres)
            {
                return distanceMetres;
            }
            else if (unit == Unit.Kilometres)
            {
                return distanceMetres / 1000;
            }
            else
            {
                return UnitConverter.MetresToMiles(distanceMetres);
            }
        }
    }
}