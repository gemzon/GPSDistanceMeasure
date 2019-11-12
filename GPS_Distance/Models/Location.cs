using GPS_Distance.Helpers;

namespace GPS_Distance.Models
{
    public class Location
    {
        public double Latitude { get; set; }  // Degrees
        public double Longitude { get; set; } // Degrees
        public double LatitudeRadians => Helper.DegreesToRadians(Latitude);
        public double LongitudeRadians => Helper.DegreesToRadians(Longitude);
    }
}
