using System.Collections.Generic;
using System.Collections.ObjectModel;
using GPS_Distance.Models;
using static GPS_Distance.MeasurementFormulas.MeasureFormula;

namespace GPS_Distance.Helpers
{
    public static partial class Helper
    {
    
        public static ObservableCollection<DistanceResult> MeasureDistance(List<Location> endpoints,
            Unit selectedUnit, MeasurementInputs measurementInputs)
        {
            ObservableCollection<DistanceResult> DistanceResults = new ObservableCollection<DistanceResult>();
            foreach (Location endLocation in endpoints)
            {
                DistanceResult result = new DistanceResult(endLocation);
                result.EndLocation = endLocation;
                result.ModifiedPythagorasResult = ModifiedPythagorasMeasure(measurementInputs, endLocation).ToUnit(selectedUnit);
                result.GreaterCircleResult = GreaterCircleMeasure(measurementInputs, endLocation).ToUnit(selectedUnit);
                result.HaversineFormulaResult = HaversineMeasure(measurementInputs, endLocation).ToUnit(selectedUnit);
                DistanceResults.Add(result);
             
            }
            return DistanceResults;
        }

      
    }
}
