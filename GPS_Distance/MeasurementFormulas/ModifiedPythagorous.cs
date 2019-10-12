using System;
using System.Collections.Generic;
using System.Text;
using GPS_Distance.Helpers;


namespace GPS_Distance.MeasurementFormulas
{
    public static class ModifiedPythagoras
    {
        public static double Measure(Location startlocation,Location endLocation)
        {
            double lat = endLocation.Latitude - startlocation.Latitude;
            double lon = endLocation.Longitude - startlocation.Longitude;

            double squaredLat = Math.Pow(69.1 * lat, 2);
            double squaredLon = Math.Pow(53.0 * lon, 2);

         

            return FormatResult.FormatDouble(Math.Sqrt(squaredLat + squaredLon));
        }
    }
}
