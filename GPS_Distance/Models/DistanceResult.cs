using System;
using System.Collections.Generic;
using System.Text;

namespace GPS_Distance.Models
{
    public class DistanceResult
    {
        public Location EndLocation { get; set; }
        public double ModifiedPythagorasResult { get; set; }
        public double GreaterCircleResult { get; set; }
        public double HaversineFormulaResult { get; set; }
    }
}
