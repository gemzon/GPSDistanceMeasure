using System;
using System.Collections.Generic;
using System.Text;

namespace GPS_Distance.Models
{
    public class MeasurementInputs
    {
        public Location StartLocationInDegrees { get; set; }
        public Location StartLocationInRadians { get; set; }
        public double EarthRadius { get; set; }
    }
}
