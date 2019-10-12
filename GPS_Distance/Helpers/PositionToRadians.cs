using System;
using System.Collections.Generic;
using System.Text;

namespace GPS_Distance.Helpers
{
    public static class PositionToRadians
    {
        public static Location ConvertToRadians(Location location) => new Location()
            {
                Latitude =    UnitConverter.DegreesToRadians(location.Latitude),
                Longitude =  UnitConverter.DegreesToRadians(location.Longitude)
            };
    }
}
