namespace GPS_Distance.Helpers
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text.Json;
    using DistanceCalculator.Helpers;
    using DistanceCalculator.Models;
    using Microsoft.Win32;

    public static partial class Helper
    {
        private static readonly string fileFilter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt|All files (*.*)|*.*";

        public static bool ImportFromJson(out Location? startPoint, out Collection<Location> endPoints)
        {
            startPoint = null; // Set out parameters.
            endPoints = new Collection<Location>();

            var fileName = @"?{""start"":[52.1,-3.2],""end"":[[15.3,16.4],[52.2,-3.3],[19.8,19.2]]}"; // Testdata starts with '?'.

            if(true) // Skip dialog (or not)..
            {
                var openFileDialog = new OpenFileDialog { Filter = fileFilter };
                if(openFileDialog.ShowDialog() == false)
                    return false;
                fileName = openFileDialog.FileName;
            }

            var json = fileName[0] == '?' ? fileName[1..] : File.ReadAllText(fileName); // REM: File reading may be moved later.

            Data data;
            try
            {
                data = JsonSerializer.Deserialize<Data>(json/*, options*/);
            } // No options right now.
            catch(JsonException)
            {
                return false;
            }

            if(data is null || data.start?.Length != 2 || data.end?[0].Length != 2)
                return false;

            startPoint = new Location(data.start[0], data.start[1]);


            // may change as might add a reference name for each of the locations.
            foreach(var item in data.end)
                if(item.Length == 2)
                    endPoints.Add(new Location(item[0], item[1]));

            return endPoints.Count > 0; // At least 1 valid route.
        }

        public static bool ExportToJson(string startLat, string startLon, Collection<Location> endPoints)
        {
            var fileName = @"testdata2.json"; // For test purpose.

            if(true) // Skip dialog (or not)..
            {
                var saveFileDialog = new SaveFileDialog
                { FileName = "GPS_Distance", DefaultExt = ".json", Filter = fileFilter };

                if(saveFileDialog.ShowDialog() == false)
                    return false;

                fileName = saveFileDialog.FileName;
            }

            var data = new Data();
            data.start = new double[] { startLat.ToDouble(), startLon.ToDouble() };

            data.end = new double[endPoints.Count][];
            for(var i = 0; i < endPoints.Count; i++)
            {
                data.end[i] = new double[] { endPoints[i].Latitude, endPoints[i].Longitude };
            }

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);

            return true;
        }

        private class Data
        {
            public double[]? start { get; set; }

            public double[][]? end { get; set; }
        }
    }
}
