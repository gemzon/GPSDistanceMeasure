using System;
using System.Collections.Generic;
using System.Text;
using GPS_Distance.Helpers;
using GPS_Distance.MeasurementFormulas;

namespace GPS_Distance.Models
{
    public class DistanceResult : Location
    {
        //public Location EndLocation { get; set; }
        public DistanceResult(Location location)
        {
            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }
        public double ModifiedPythagorasResult(Unit selectedUnit, MeasurementInputs measurementInputs)
        {
            double measureResult = ModifiedPythagoras.Measure(measurementInputs, this);
            return Helper.FormatDouble(UnitConverter.DistanceToUnit(selectedUnit, measureResult));
        }

        public double GreaterCircleResult(Unit selectedUnit, MeasurementInputs measurementInputs)
        {
            double measureResult = GreaterCircle.Measure(measurementInputs, this);
            return Helper.FormatDouble(UnitConverter.DistanceToUnit(selectedUnit, measureResult));
        }

        public double HaversineFormulaResult(Unit selectedUnit, MeasurementInputs measurementInputs)
        {
            double measureResult = HaversineFormula.Measure(measurementInputs, this);
            return Helper.FormatDouble(UnitConverter.DistanceToUnit(selectedUnit, measureResult));
        }
    }
}

/*
private static void ModifiedPythagorasMeasure(DistanceResult distanceResult, Unit selectedUnit, Location measurementInputs)
{
    double measureResult = ModifiedPythagoras.Measure(measurementInputs, distanceResult);
    distanceResult.ModifiedPythagorasResult = FormatResult.FormatDouble(UnitConverter.DistanceToUnit(selectedUnit, measureResult));
}

private static void GreatCircleMeasure(DistanceResult distanceResult, Location endLocationInRadian, Unit selectedUnit, MeasurementInputs measurementInputs)
{
    double measureResult = GreaterCircle.Measure(measurementInputs, endLocationInRadian, measurementInputs.EarthRadius);
    distanceResult.GreaterCircleResult = FormatResult.FormatDouble(UnitConverter.DistanceToUnit(selectedUnit, measureResult));
}

private static void HaversineForumlaMeasure(DistanceResult distanceResult, Location endLocationInRadian, Unit selectedUnit, MeasurementInputs measurementInputs)
{
    double measureResult = HaversineFormula.Measure(measurementInputs, endLocationInRadian, measurementInputs.EarthRadius);
    distanceResult.HaversineFormulaResult = FormatResult.FormatDouble(UnitConverter.DistanceToUnit(selectedUnit, measureResult));
}
*/
