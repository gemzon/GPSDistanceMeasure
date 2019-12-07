namespace DistanceCalculator.Models
{
    using static DistanceCalculator.Helpers.Helper;
    using static MapUtils.Lookup;

    public class Location
    {
        public Location()
        {
        }

        public Location(Location location) : this(location.Latitude, location.Longitude) { }
        public Location(double latitude, double longitude)
        {
            Latitude = latitude; LatitudeRadians = DegreesToRadians(latitude);
            Longitude = longitude; LongitudeRadians = DegreesToRadians(longitude);
        }

        // Properties
        public double Latitude { get; }  // Degrees
        public double Longitude { get; } // Degrees
        public double LatitudeRadians { get; }
        public double LongitudeRadians { get; }
        public double EarthRadius => RadiusLatitudeAdjustment(Latitude);
        public string LocationShort => $"Lat: {Latitude}, Lon: {Longitude}";
        public string LocationLong => $"Latitude: {Latitude}, Longitude: {Longitude}";
        public string DisplayName => DisplayName(Latitude, Longitude);
        public string District => District(Latitude, Longitude);
    }
}
