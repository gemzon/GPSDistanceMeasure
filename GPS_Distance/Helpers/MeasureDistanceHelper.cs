using GPS_Distance.MeasurementFormulas;
using GPS_Distance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GPS_Distance.Helpers
{
    public static class MeasureDistanceHelper
    {

        //public static double GetEarthRadius(double startLatInDegree)
        //    => RadiusLatitudeAdjustment.LatitudeAdjustment(startLatInDegree);

        //public static Location ConvertStartLocationToRadians(Location startLocationInDegree)
        //    => PositionToRadians.ConvertToRadians(startLocationInDegree);

        public static ObservableCollection<DistanceResult> MeasureDistance(ObservableCollection<Location> endpoints,
            Unit selectedUnit, MeasurementInputs measurementInputs)
        {
            ObservableCollection<DistanceResult> DistanceResults = new ObservableCollection<DistanceResult>();
            foreach (Location location in endpoints)
            {
                DistanceResult result = new DistanceResult(location);
                //{
                //    EndLocation = location
                //};
                //var endLocationInRadian = PositionToRadians.ConvertToRadians(location);
                //ModifiedPythagorasMeasure(result, selectedUnit, measurementInputs);
                //GreatCircleMeasure(result, location, selectedUnit, measurementInputs);
                //HaversineForumlaMeasure(result, location, selectedUnit, measurementInputs);

            }
            return DistanceResults;
        }


        //private static void ModifiedPythagorasMeasure(DistanceResult distanceResult, Unit selectedUnit, Location measurementInputs)
        //{

        //    double measureResult = ModifiedPythagoras.Measure(measurementInputs, distanceResult);

        //    distanceResult.ModifiedPythagorasResult = FormatResult.FormatDouble(UnitConverter.ConvertUnit(selectedUnit, measureResult));
        //}

        //private static void GreatCircleMeasure(DistanceResult distanceResult, Location endLocationInRadian, Unit selectedUnit, MeasurementInputs measurementInputs)
        //{

        //    double measureResult = GreaterCircle.Measure(measurementInputs, endLocationInRadian, measurementInputs.EarthRadius);

        //    distanceResult.GreaterCircleResult = FormatResult.FormatDouble(UnitConverter.ConvertUnit(selectedUnit, measureResult));
        //}

        //private static void HaversineForumlaMeasure(DistanceResult distanceResult, Location endLocationInRadian,
        //    Unit selectedUnit, MeasurementInputs measurementInputs)
        //{
        //    double measureResult = HaversineFormula.Measure(measurementInputs, endLocationInRadian, measurementInputs.EarthRadius);

        //    distanceResult.HaversineFormulaResult = FormatResult.FormatDouble(UnitConverter.ConvertUnit(selectedUnit, measureResult));
        //}
    }
}
