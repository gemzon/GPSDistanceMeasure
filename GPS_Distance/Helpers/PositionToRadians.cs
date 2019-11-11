using GPS_Distance.Models;

namespace GPS_Distance.Helpers
{
    public static partial class Helper
    {
        public static Location ConvertToRadians(Location location) => new Location()
        {
            Latitude = Helper.DegreesToRadians(location.Latitude),
            Longitude = Helper.DegreesToRadians(location.Longitude)
        };
    }
}
