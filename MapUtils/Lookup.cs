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

        public static string District(double latitude, double longitude) // Under construction.. Kind of messy right now..
        {
            var adr = geo.Lookup(latitude, longitude, out _);

            string grp1, grp2, grp3, grp5 = "", grp6 = ""; // Find out the `right´ order for each (G)roup.
            int n = 0, max = 3;

            grp1 = abc(new string[] { adr.Name + " (n)" }, ref n); // Temp (_).

            grp2 = abc(new string[] { adr.HouseNumber + " (h)", adr.Road + " (r)", adr.PostCode + " (p)" }, ref n);

            grp3 = abc(new string[] { adr.Hamlet + " (h)", adr.Village + " (v)", adr.Suburb + " (s)", adr.Town + " (t)", adr.City + " (c)" }, ref n);

            if (n < max)
                grp5 = abc(new string[] { adr.County + " (c)", adr.District + " (d)", adr.Region + " (r)", adr.State + " (s)" }, ref n);

            if (n < max)
                grp6 = abc(new string[] { adr.Country }, ref n);

            return def(new string[] { grp1, grp2, grp3, grp5, grp6 }, max); // What if strings are empty... Show the 3 most significant.

            static string abc(string[] fields, ref int n)
            {
                foreach (var f in fields)
                    if (!string.IsNullOrWhiteSpace(f)) { n++; return f; };

                return string.Empty;
            }

            static string def(string[] fields, int max)
            {
                var s = string.Empty;
                var n = 0;
                foreach (var f in fields)
                {
                    if (!string.IsNullOrWhiteSpace(f)) if (n == 0) s = f; else s += ", " + f;
                    if (++n >= max) return s;
                }
                return string.Empty;
            }
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
