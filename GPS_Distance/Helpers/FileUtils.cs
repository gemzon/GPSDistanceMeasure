namespace GPS_Distance.Helpers
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text.Json;
    using DistanceCalculator.Models;
    using Microsoft.Win32;
    using static DistanceCalculator.Helpers.Helper;

    public static partial class Helper
    {
        public static bool ImportFromJson(out Location? startPoint, out ObservableCollection<Location> endPoints)
        {
            startPoint = null; // Set out parameters.
            endPoints = new ObservableCollection<Location>();

            var fileName = @"?{""start"":[52.1,-3.2],""end"":[[15.3,16.4],[52.2,-3.3],[19.8,19.2]]}"; // Testdata starts with '?'.

            if (false) // Skip dialog (or not)..
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == false) return false;
                fileName = openFileDialog.FileName;
            }

            var json = fileName[0] == '?' ? fileName[1..] : File.ReadAllText(fileName); // REM: File reading may be moved later.

            Data data;
            try { data = JsonSerializer.Deserialize<Data>(json/*, options*/); }
            catch (JsonException) { return false; }

            if (data is null || data.start?.Length != 2 || data.end?[0].Length != 2) return false;

            if (!valid(data.start, out var latitude, out var longitude)) return false;
            startPoint = new Location(latitude, longitude);

            foreach (var item in data.end)
                if (item.Length == 2 && valid(item, out latitude, out longitude))
                    endPoints.Add(new Location(latitude, longitude));

            return endPoints.Count > 0; // At least 1 valid route.

            static bool valid(double[] coord, out double lat, out double lon)
            {
                lon = 0;
                return TryParseLatitude(coord[0].ToString(), out lat) && TryParseLongitude(coord[1].ToString(), out lon);
            }
        }
        private class Data
        {
            public double[]? start { get; set; }
            public double[][]? end { get; set; }
        }
    }
}
