using static GPS_Distance.Helpers.Helper;

namespace GPS_Distance.Models
{
    public class MeasurementInputs : Location
    {
        public MeasurementInputs() { }
        public MeasurementInputs(Location location) : base(location) { }
        public MeasurementInputs(double latitude, double longitude) : base(latitude, longitude) { }

        // Properties
        public double EarthRadius => RadiusLatitudeAdjustment(Latitude);
    }
}
