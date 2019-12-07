namespace MapUtils
{
    using System;
    using Geocoder.API.Address;
    using static System.String;
    using static System.StringSplitOptions;

    public static class Lookup
    {
        private static readonly GeoSearcher geo = new GeoSearcher();
        public static string DisplayName(double latitude, double longitude) // Work in progress..
        {
            geo.Lookup(latitude, longitude, out var displayName);

            return displayName;
        }

        public static string ShortName(double latitude, double longitude) // Still under construction..
        {
            var adr = geo.Lookup(latitude, longitude, out _);

            if (adr is null) return Empty;

            string grp1, grp2, grp3, grp5, grp6; // Find out the `right´ order for each group.

            grp1 = adr.Name.Z('n');

            grp2 = TakeN(new string[] { Join(' ', new string[] { adr.HouseNumber.Z('h'), adr.Road.Z('r') }).Trim(), adr.PostCode.Z('p') });

            grp3 = TakeN(new string[] { adr.Hamlet.Z('h'), adr.Village.Z('v'), adr.Suburb.Z('s'), adr.Town.Z('t'), adr.City.Z('c') });

            grp5 = TakeN(new string[] { adr.County.Z('c'), adr.District.Z('d'), adr.Region.Z('r'), adr.State.Z('s') });

            grp6 = TakeN(new string[] { adr.Country.Z('c'), adr.CountryCode.Z('y') });

            return TakeN(new string[] { grp1, grp2, grp3, grp5, grp6 }, 3); // Return the 3 most significant fields (if they exist).
        }
        static string Z(this string s, char ch) => IsNullOrEmpty(s) ? Empty : $"{s} ({ch})"; // Add temp suffix.
        static string TakeN(string[] fields, int n = 1) // Return max N fields (default 1 field).
        {
            var arr = Join('|', fields).TrimStart('|').Split('|', RemoveEmptyEntries);
            return Join(", ", arr, 0, Math.Min(n, arr.Length));
        }
    }
}

/*               Group   Order  (regroup/reorder?)
------------------------------
Pedestrian         0       -

Name               1       ?

HouseNumber        2       1
Road               2       2
PostCode           2       3

Hamlet             3       1
Village            3       2
Suburb             3       3
Town               3       4    Split to subgroup?
City               3       5

Neighborhood       4       -

County             5
District           5
Region             5            Split to subgroup?
State              5

CountryCode        6
Country            6
*/
