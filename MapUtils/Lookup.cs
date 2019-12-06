namespace MapUtils
{
    using Geocoder.API.Address;

    public class Lookup
    {
        private static readonly GeoSearcher geo = new GeoSearcher();
        public static string DisplayName(double latitude, double longitude) // Work in progress..
        {
            geo.Lookup(latitude, longitude, out var displayName);

            return displayName;
        }

        public static string District(double latitude, double longitude) // Under construction..
        {
            var adr = geo.Lookup(latitude, longitude, out _);

            string s1 = "", s2 = "", s3 = ""; // Find out the `right´ order for each group.

            if (adr.Village != "") s1 = adr.Village + " (v)"; // Temp (_).
            else if (adr.Town != "") s1 = adr.Town + " (t)";
            else if (adr.City != "") s1 = adr.City + " (c)";

            if (adr.Suburb != "") s2 += adr.Suburb + " (s)";
            else if (adr.Country != "") s2 += adr.County + " (c)";
            else if (adr.District != "") s2 += adr.District + " (d)";
            else if (adr.Region != "") s2 += adr.Region + " (r)";

            if (adr.Country != "") s3 += adr.Country;

            return $"{s1}, {s2}, {s3}"; // What if strings are empty...
        }
    }
}
