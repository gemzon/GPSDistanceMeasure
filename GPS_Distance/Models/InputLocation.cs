using System;
using System.Collections.Generic;
using System.Text;

namespace GPS_Distance.Models
{
    // class is for the entryform inputs
    public class InputLocation
    {
        
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public InputLocation(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }
    }

    
}
