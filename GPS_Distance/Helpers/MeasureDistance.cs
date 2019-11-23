using System.Collections.Generic;
using System.Collections.ObjectModel;
using GPS_Distance.Models;
using static GPS_Distance.MeasurementFormulas.MeasureFormula;

namespace GPS_Distance.Helpers
{
    public static partial class Helper
    {
        public static ObservableCollection<DistanceResult> MeasureDistance(MeasurementInputs measurementInputs, List<Location> endpoints, Unit selectedUnit)
        {
            ObservableCollection<DistanceResult> DistanceResults = new ObservableCollection<DistanceResult>();
            foreach (Location endLocation in endpoints)
            {
                DistanceResults.Add(new DistanceResult(endLocation)
                {
                    ModifiedPythagorasResult = ModifiedPythagorasMeasure(measurementInputs, endLocation).ToUnit(selectedUnit),
                    GreaterCircleResult = GreaterCircleMeasure(measurementInputs, endLocation).ToUnit(selectedUnit),
                    HaversineFormulaResult = HaversineMeasure(measurementInputs, endLocation).ToUnit(selectedUnit)
                });
            }
            return DistanceResults;
        }
    }
}
