using static GPS_Distance.Helpers.Helper;

namespace GPS_Distance.Models
{
    public class Location
    {
        public Location() { }
        public Location(Location location) : this(location.Latitude, location.Longitude) { }
        public Location(double latitude, double longitude) { Latitude = latitude; Longitude = longitude; }

        private double latitude;
        private double longitude;

        // Properties
        public double Latitude // Degrees
        {
            get => latitude;
            set { latitude = value; LatitudeRadians = DegreesToRadians(value); }
        }
        public double Longitude // Degrees
        {
            get => longitude;
            set { longitude = value; LongitudeRadians = DegreesToRadians(value); }
        }
        public double LatitudeRadians { get; private set; }
        public double LongitudeRadians { get; private set; }
    }
}
