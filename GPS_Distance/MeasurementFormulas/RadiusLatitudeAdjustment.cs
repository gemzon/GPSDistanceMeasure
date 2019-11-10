﻿using System;

namespace GPS_Distance.MeasurementFormulas
{
    public static class RadiusLatitudeAdjustment
    {
        public static double LatitudeAdjustment(double Latitude)
        {
            const double EquatorialEarthRadius = 6378137;
            const double PoleEarthRadius = 6371001;

            double value1 = Math.Pow(Math.Pow(EquatorialEarthRadius, 2) * Math.Cos(Latitude), 2);
            double value2 = Math.Pow(Math.Pow(PoleEarthRadius, 2) * Math.Sin(Latitude), 2);

            double value3 = Math.Pow(EquatorialEarthRadius * Math.Cos(Latitude), 2);
            double value4 = Math.Pow(PoleEarthRadius * Math.Sin(Latitude), 2);

            return Math.Sqrt((value1 + value2) / (value3 + value4));
        }
    }
}
