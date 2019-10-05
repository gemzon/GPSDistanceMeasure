using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPS_Distance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double ModifiedPythagorasResult;
        public double GreaterCircleResult;
        public double HaversineFormulaResult;
        public double EquatorialEarthRadius;
        public Location StartLocation;
        public Location EndLocation;
        double startLatInRadians;
        double startLonInRadians;
        double endLatInRadians;
        double endLonInRadians;

        public MainWindow()
        {
            InitializeComponent();
            ModifiedPythagorasResult = 0.0;
            GreaterCircleResult = 0.0;
            HaversineFormulaResult = 0.0;
            //EquatorialEarthRadius = 6378137.0;
            EquatorialEarthRadius = 6365631;
            StartLocation = new Location();
             EndLocation = new Location();
        }

        private void MeasureDistanceBtn_Click(object sender, RoutedEventArgs e)
        {  
            StartLocation.Latitude = ParseStringValueToDouble(StartLatTxtBx.Text);
            StartLocation.Longitude = ParseStringValueToDouble(StartLonTxtBx.Text);
            EndLocation.Latitude = ParseStringValueToDouble(EndLatTxtBx.Text);
            EndLocation.Longitude = ParseStringValueToDouble(EndLonTxtBx.Text);
            startLatInRadians = 0.0;
            startLonInRadians = 0.0 ;
            endLatInRadians = 0.0;
            endLonInRadians = 0.0;

            startLatInRadians = UnitConverter.DegreesToRadians(StartLocation.Latitude);
            startLonInRadians = UnitConverter.DegreesToRadians(StartLocation.Longitude);
            endLatInRadians = UnitConverter.DegreesToRadians(EndLocation.Latitude);
            endLonInRadians = UnitConverter.DegreesToRadians(EndLocation.Longitude);

            MeasureUsingModifiedPythagorous();
            MeasureGreaterCircle();
            MeasureHaversineForumla();


            ModifiedPythagorousResultTxtBx.Text = ModifiedPythagorasResult.ToString();
            GreaterCircleResultTxtBx.Text = GreaterCircleResult.ToString();
            HaversineFormulaResultTxtBx.Text = HaversineFormulaResult.ToString();
        }

        private void MeasureUsingModifiedPythagorous()
        {
            double lat = EndLocation.Latitude - StartLocation.Latitude;
            double lon = EndLocation.Longitude - StartLocation.Longitude;

            double squaredLat = Math.Pow(69.1 * lat,2) ;
            double squaredLon = Math.Pow(53.0 * lon, 2);

            ModifiedPythagorasResult = Math.Sqrt(squaredLat + squaredLon);    
        }

        private void MeasureGreaterCircle()
        {
           
            double sineAngle = Math.Sin(startLatInRadians) * Math.Sin(endLatInRadians);
            double cosAngle = Math.Cos(startLatInRadians) *  Math.Cos(endLatInRadians) *
                Math.Cos(endLonInRadians - startLonInRadians);

            double distanceInRadians = EquatorialEarthRadius * Math.Acos(sineAngle + cosAngle);

            GreaterCircleResult = UnitConverter.RadiansToDegrees(distanceInRadians);

        }

        private void MeasureHaversineForumla()
        {
                
            double dlat = UnitConverter.DegreesToRadians(EndLocation.Latitude - StartLocation.Latitude);
           
            double dlon = UnitConverter.DegreesToRadians(EndLocation.Longitude - StartLocation.Longitude);

            double squared = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) + Math.Sin(dlon/2) * Math.Sin(dlon / 2) * Math.Cos(startLatInRadians) * Math.Cos(endLatInRadians);
         
            double distanceInRadians = EquatorialEarthRadius * 2 * Math.Asin(Math.Sqrt(squared));
            HaversineFormulaResult = UnitConverter.RadiansToDegrees(distanceInRadians);
        }

        private double ParseStringValueToDouble(string value)
        {
            if(value == null)
            {
                //Todo show error message
            }

            return double.Parse(value);
        }

        private void ClearStartValuesBtn_Click(object sender, RoutedEventArgs e)
        {
            StartLatTxtBx.Text = "";
            StartLonTxtBx.Text = "";
            StartLocation = new Location();
            ModifiedPythagorasResult = 0.0;
            GreaterCircleResult = 0.0;
            HaversineFormulaResult = 0.0;
        }

        private void ClearEndValuesBtn_Click(object sender, RoutedEventArgs e)
        {
            EndLatTxtBx.Text = "";
            EndLonTxtBx.Text = "";
            EndLocation = new Location();
            ModifiedPythagorasResult = 0.0;
            GreaterCircleResult = 0.0;
            HaversineFormulaResult = 0.0;
        }

        private void ClearResultsValuesBtn_Click(object sender, RoutedEventArgs e)
        {
            ModifiedPythagorousResultTxtBx.Text = "";
            GreaterCircleResultTxtBx.Text = "";
            HaversineFormulaResultTxtBx.Text = "";
            ModifiedPythagorasResult = 0.0;
            GreaterCircleResult = 0.0;
            HaversineFormulaResult = 0.0;

        }

        private void ClearAllBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearStartValuesBtn_Click(this, null);
            ClearEndValuesBtn_Click(this, null);
            ClearResultsValuesBtn_Click(this, null);

        }
    }
}
