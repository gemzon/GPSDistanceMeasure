using System.Collections.ObjectModel;
using GPS_Distance.MeasurementFormulas;
using GPS_Distance.Models;

namespace GPS_Distance.Helpers
{
    public static partial class Helper
    {
        //public static double GetEarthRadius(double startLatInDegree)
        //    => RadiusLatitudeAdjustment.LatitudeAdjustment(startLatInDegree);

        //public static Location ConvertStartLocationToRadians(Location startLocationInDegree)
        //    => Helper.ConvertToRadians(startLocationInDegree);

        public static ObservableCollection<DistanceResult> MeasureDistance(ObservableCollection<Location> endpoints,
            Unit selectedUnit, MeasurementInputs measurementInputs)
        {
            ObservableCollection<DistanceResult> DistanceResults = new ObservableCollection<DistanceResult>();
            foreach (Location endLocation in endpoints)
            {
                DistanceResult result = new DistanceResult(endLocation);
                //{
                //    EndLocation = endLocation
                //};
                //var endLocationInRadian = Helper.ConvertToRadians(endLocation);

                //ModifiedPythagorasMeasure(result, selectedUnit, measurementInputs);

                // NOTE: result now contains endLocation, redundant parameter, or?
                //GreatCircleMeasure(result, endLocation, selectedUnit, measurementInputs);
                //HaversineForumlaMeasure(result, endLocation, selectedUnit, measurementInputs);

                result.ModifiedPythagorasResult = ModifiedPythagoras.Measure(measurementInputs, /*result*/endLocation).ToUnit(selectedUnit);
                result.GreaterCircleResult = GreaterCircle.Measure(measurementInputs, endLocation).ToUnit(selectedUnit);
                result.HaversineFormulaResult = HaversineFormula.Measure(measurementInputs, endLocation).ToUnit(selectedUnit);

                // NOTE: Is this missing or how does it work?
                //DistanceResults.Add(result);
            }
            return DistanceResults;
        }

        //private static void ModifiedPythagorasMeasure(DistanceResult distanceResult,
        //    Unit selectedUnit, MeasurementInputs measurementInputs)
        //{
        //    //double measureResult = ModifiedPythagoras.Measure(measurementInputs, distanceResult);
        //    //distanceResult.ModifiedPythagorasResult = Helper.FormatDouble(Helper.ConvertUnit(selectedUnit, measureResult));

        //    distanceResult.ModifiedPythagorasResult = ModifiedPythagoras.Measure(measurementInputs, distanceResult).ToUnit(selectedUnit);
        //}

        //// NOTE: distanceResult now contains endLocation, redundant parameter, or?

        //private static void GreatCircleMeasure(DistanceResult distanceResult, Location endLocation,
        //    Unit selectedUnit, MeasurementInputs measurementInputs)
        //{
        //    //double measureResult = GreaterCircle.Measure(measurementInputs, endLocation/*, measurementInputs.EarthRadius*/);
        //    //distanceResult.GreaterCircleResult = Helper.FormatDouble(Helper.ConvertUnit(selectedUnit, measureResult));

        //    distanceResult.GreaterCircleResult = GreaterCircle.Measure(measurementInputs, endLocation).ToUnit(selectedUnit);
        //}

        //private static void HaversineForumlaMeasure(DistanceResult distanceResult, Location endLocation,
        //    Unit selectedUnit, MeasurementInputs measurementInputs)
        //{
        //    //double measureResult = HaversineFormula.Measure(measurementInputs, endLocation/*, measurementInputs.EarthRadius*/);
        //    //distanceResult.HaversineFormulaResult = Helper.FormatDouble(Helper.ConvertUnit(selectedUnit, measureResult));

        //    distanceResult.HaversineFormulaResult = HaversineFormula.Measure(measurementInputs, endLocation).ToUnit(selectedUnit);
        //}
    }
}
