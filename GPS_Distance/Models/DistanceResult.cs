namespace GPS_Distance.Models
{
    public class DistanceResult : Location
    {
        //public Location EndLocation { get; set; }
        public DistanceResult(Location location)
        {
            this.Latitude = location.Latitude;
            this.Longitude = location.Longitude;
        }
        public double ModifiedPythagorasResult { get; set; }
        public double GreaterCircleResult { get; set; }
        public double HaversineFormulaResult { get; set; }
    }
}
