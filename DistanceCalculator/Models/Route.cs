namespace DistanceCalculator.Models
{
    using System;

    public class Route
    {
        public Route(Location start, Location end) { Start = start; End = end; }

        // Properties
        public Location Start { get; }
        public Location End { get; }
        public double GreaterCircle => GreaterCircleMeasure(this);
        public double Haversine => HaversineMeasure(this);
        public double ModifiedPythagoras => ModifiedPythagorasMeasure(this);

        #region Private
        #region Properties
        private double DiffLatRad => End.LatitudeRadians - Start.LatitudeRadians;
        private double DiffLonRad => End.LongitudeRadians - Start.LongitudeRadians;
        #endregion
        #region Methods
        private static double GreaterCircleMeasure(Route route)
        {
            double sineAngle = Math.Sin(route.Start.LatitudeRadians) * Math.Sin(route.End.LatitudeRadians);
            double cosAngle = Math.Cos(route.Start.LatitudeRadians) * Math.Cos(route.End.LatitudeRadians) * Math.Cos(route.DiffLonRad);

            return route.Start.EarthRadius * Math.Acos(sineAngle + cosAngle); // distanceMetres
        }
        private static double HaversineMeasure(Route route)
        {
            double squaredSinLat = Math.Sin(route.DiffLatRad / 2) * Math.Sin(route.DiffLatRad / 2);
            double squaredSinLon = Math.Sin(route.DiffLonRad / 2) * Math.Sin(route.DiffLonRad / 2);

            double squaredCos = Math.Cos(route.Start.LatitudeRadians) * Math.Cos(route.End.LatitudeRadians);

            double squared = squaredSinLat + squaredSinLon * squaredCos;

            return route.Start.EarthRadius * 2 * Math.Asin(Math.Sqrt(squared)); // distanceMetres
        }
        private static double ModifiedPythagorasMeasure(Route route)
        {
            double squaredLat = Math.Pow(69.1 * (route.End.Latitude - route.Start.Latitude), 2);
            double squaredLon = Math.Pow(53.0 * (route.End.Longitude - route.Start.Longitude), 2);

            return Math.Sqrt(squaredLat + squaredLon); // distanceMetres
        }
        #endregion
        #endregion
    }
}
