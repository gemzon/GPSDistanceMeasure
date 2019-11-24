using System.Collections.Generic;
using System.Collections.ObjectModel;
using DistanceCalculator.Models;
using static DistanceCalculator.MeasurementFormulas.MeasureFormula;

namespace DistanceCalculator.Helpers
{
    public static partial class Helper
    {

        public static ObservableCollection<DistanceResult> MeasureDistance(List<Location> endpoints,
                                                                           Unit selectedUnit,
                                                                           MeasurementInputs measurementInputs)
        {
            ObservableCollection<DistanceResult> DistanceResults = new ObservableCollection<DistanceResult>();
            foreach (Location endLocation in endpoints)
            {
                DistanceResult result = new DistanceResult(endLocation)
                {
                    EndLocation = $"Lat: {endLocation.Latitude},Lon:{endLocation.Longitude}",
                    ModifiedPythagorasResult =  ModifiedPythagorasMeasure(measurementInputs, endLocation).ToUnit(selectedUnit),
                    GreaterCircleResult = GreaterCircleMeasure(measurementInputs, endLocation).ToUnit(selectedUnit),
                    HaversineFormulaResult = HaversineMeasure(measurementInputs, endLocation).ToUnit(selectedUnit),
                };
                DistanceResults.Add(result);
            }



            return DistanceResults;

        }

    }
}
