namespace GPS_Distance.Models
{
    public class DistanceResult : Location
    {
        //public Location EndLocation { get; set; }
        public DistanceResult(Location location) : base(location.Latitude, location.Longitude) { }
        public double ModifiedPythagorasResult { get; set; }
        public double GreaterCircleResult { get; set; }
        public double HaversineFormulaResult { get; set; }
    }
}
