using GPS_Distance.MeasurementFormulas;

namespace GPS_Distance.Models
{
    public class MeasurementInputs : Location
    {
        //public Location StartLocationInDegrees { get; set; }
        //public Location StartLocationInRadians { get; set; }
        //public double EarthRadius { get; set; }
        public double EarthRadius => RadiusLatitudeAdjustment.LatitudeAdjustment(Latitude);
    }
}
