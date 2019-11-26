using System;
using DistanceCalculator.Models;

namespace DistanceCalculator.MeasurementFormulas
{
    public static partial class MeasureFormula
    {
        public static double GreaterCircleMeasure(MeasurementInputs startLocation, Location endLocation)
        {
            double sineAngle = Math.Sin(startLocation.LatitudeRadians) * Math.Sin(endLocation.LatitudeRadians);
            double cosAngle = Math.Cos(startLocation.LatitudeRadians) * Math.Cos(endLocation.LatitudeRadians)
                            * Math.Cos(endLocation.LongitudeRadians - startLocation.LongitudeRadians);

            double distanceMetres = startLocation.EarthRadius * Math.Acos(sineAngle + cosAngle);

            return distanceMetres;
        }
    }
}
