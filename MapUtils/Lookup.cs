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

            string grp1 = "", grp2 = "", grp3 = "", grp5 = "", grp6 = ""; // Find out the `right´ order for each (G)roup.

            if (adr.Name != "") grp1 = adr.Name + " (n)"; // Temp (_).

            if (adr.HouseNumber != "") grp2 = adr.HouseNumber + " (h)";
            else if  (adr.Road != "") grp2 = adr.Road + " (r)";
            else if  (adr.PostCode != "") grp2 = adr.PostCode + " (p)";

            if (adr.Hamlet != "") grp3 = adr.Hamlet + " (h)";
            else if (adr.Village != "") grp3 = adr.Village + " (v)";
            else if (adr.Suburb != "") grp3 = adr.Suburb + " (s)";
            else if (adr.Town != "") grp3 = adr.Town + " (t)";
            else if (adr.City != "") grp3 = adr.City + " (c)";

            if (adr.County != "") grp5 += adr.County + " (c)";
            else if (adr.District != "") grp5 += adr.District + " (d)";
            else if (adr.Region != "") grp5 += adr.Region + " (r)";
            else if (adr.State != "") grp5 += adr.State + " (s)";

            if (adr.Country != "") grp6 += adr.Country;

            return $"{grp1}, {grp2} , {grp3}, {grp5}, {grp6}"; // What if strings are empty... Show the 3 most significant.
        }
    }
}

/*                  Group   Order   (my personal guess (not native English address understanding))
---------------------------------
Pedestrian          0       -

Name                1       ?

HouseNumber         2       1
Road                2       2
PostCode            2       3

Hamlet              3       1
Village             3       2
Suburb              3       3
Town                3       4
City                3       5

Neighborhood        4

County              5
District            5
Region              5
State               5

CountryCode         6
Country             6
*/
