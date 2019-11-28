namespace GPS_Distance.Helpers
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text.Json;
    using DistanceCalculator.Models;

    public static partial class Helper
    {
        public static bool ImportFromJson(string fileName, out Location? startPoint, out ObservableCollection<Location> endPoints)
        {
            startPoint = null; // Set out parameters.
            endPoints = new ObservableCollection<Location>();

            var json = fileName[0] == '?' ? fileName[1..] : File.ReadAllText(fileName); // REM: File reading may be moved later.
            var data = JsonSerializer.Deserialize<Data>(json/*, options*/);

            if (data is null || data.start?.Length != 2 || data.end?[0].Length != 2) return false;

            startPoint = new Location(data.start[0], data.start[1]); // REM: Check numerics.
            foreach (var item in data.end) if (item.Length == 2) endPoints.Add(new Location(item[0], item[1]));

            return true;
        }

        private class Data
        {
            public double[]? start { get; set; }
            public double[][]? end { get; set; }
        }
    }
}
