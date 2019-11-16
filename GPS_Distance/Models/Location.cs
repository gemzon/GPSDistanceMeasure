using static GPS_Distance.Helpers.Helper;

namespace GPS_Distance.Models
{
    public class Location
    {
        public Location() { }
        public Location(Location location) : this(location.Latitude, location.Longitude) { }
        public Location(double latitude, double longitude) { Latitude = latitude; Longitude = longitude; }

        // Properties
        public double Latitude { get; set; }  // Degrees
        public double Longitude { get; set; } // Degrees
        public double LatitudeRadians => DegreesToRadians(Latitude);
        public double LongitudeRadians => DegreesToRadians(Longitude);
    }
}
