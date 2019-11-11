using GPS_Distance.Helpers;
using GPS_Distance.MeasurementFormulas;

namespace GPS_Distance.Models
{
    public interface ILocation
    {
        public double Latitude { get; set; } // Degrees
    }

    public class Location : ILocation
    {
        public double Latitude { get; set; }  // Degrees
        public double Longitude { get; set; } // Degrees
        public double LatitudeRadians => UnitConverter.DegreesToRadians(Latitude);
        public double LongitudeRadians => UnitConverter.DegreesToRadians(Longitude);

        //public double EarthRadius => RadiusLatitudeAdjustment.LatitudeAdjustment(Latitude);
    }
}
