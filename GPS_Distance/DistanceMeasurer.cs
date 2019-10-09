using System;

namespace GPS_Distance
{
    /// <summary>
    /// A helper for measuring distances using different algorithms. 
    /// </summary>
    public class DistanceMeasurer
    {
        public double MeasureUsingModifiedPythagorous(
            Location startLocationInDegrees, 
            Location endLocationInDegrees)
        {
            double lat = endLocationInDegrees.Latitude - startLocationInDegrees.Latitude;
            double lon = endLocationInDegrees.Longitude - startLocationInDegrees.Longitude;

            double squaredLat = Math.Pow(69.1 * lat, 2);
            double squaredLon = Math.Pow(53.0 * lon, 2);

            return Math.Sqrt(squaredLat + squaredLon);
        }

        public double MeasureGreaterCircle(
            Location startLocationInRadians, 
            Location endLocationInRedians, 
            double equatorialEarthRadius)
        {
            double sineAngle = Math.Sin(startLocationInRadians.Latitude) * Math.Sin(endLocationInRedians.Latitude);
            double cosAngle = Math.Cos(startLocationInRadians.Latitude) * Math.Cos(endLocationInRedians.Latitude) *
                Math.Cos(endLocationInRedians.Longitude - startLocationInRadians.Longitude);

            double distanceMetres = equatorialEarthRadius * Math.Acos(sineAngle + cosAngle);

            return UnitConverter.MetresToMiles(distanceMetres);
        }

        public double MeasureHaversineForumla(
            Location startLocationInRadians,
            Location endLocationInRedians,
            double equatorialEarthRadius)
        {
            double dlat = endLocationInRedians.Latitude - startLocationInRadians.Latitude;

            double dlon = endLocationInRedians.Longitude - startLocationInRadians.Longitude;

            double squaredSinDlat = Math.Sin(dlat / 2) * Math.Sin(dlat / 2);

            double squaredSinLon = Math.Sin(dlon / 2) * Math.Sin(dlon / 2);

            double squaredCos = Math.Cos(startLocationInRadians.Latitude) * Math.Cos(endLocationInRedians.Latitude);


            double squared = squaredSinDlat + squaredSinLon * squaredCos;
            double distanceMetres = equatorialEarthRadius * 2 * Math.Asin(Math.Sqrt(squared));
            return UnitConverter.MetresToMiles(distanceMetres);
        }
    }
}
