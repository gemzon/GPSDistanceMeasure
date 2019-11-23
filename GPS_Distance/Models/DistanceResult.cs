namespace GPS_Distance.Models
{
    public class DistanceResult : Location
    {
        public DistanceResult(Location location) : base(location) { }

        // Properties
        //public Location EndLocation { get; set; }
        public double ModifiedPythagorasResult { get; set; }
        public double GreaterCircleResult { get; set; }
        public double HaversineFormulaResult { get; set; }
    }
}
