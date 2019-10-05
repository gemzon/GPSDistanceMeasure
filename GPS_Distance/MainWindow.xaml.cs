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
        public Location StartLocationInDegrees;
        public Location StartLocationInRadian;
        public Location EndLocationInDegrees;
        public Location EndLocationInRadian;
      

        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void MeasureDistanceBtn_Click(object sender, RoutedEventArgs e)
        {
            InitializeValues();
            GetPositionsValues();

            PostionsToRadians();

            MeasureUsingModifiedPythagorous();
            MeasureGreaterCircle();
            MeasureHaversineForumla();


            ModifiedPythagorousResultTxtBx.Text = ModifiedPythagorasResult.ToString();
            GreaterCircleResultTxtBx.Text = GreaterCircleResult.ToString();
            HaversineFormulaResultTxtBx.Text = HaversineFormulaResult.ToString();
        }

        private void InitializeValues()
        {
            ModifiedPythagorasResult = 0.0;
            GreaterCircleResult = 0.0;
            HaversineFormulaResult = 0.0;
            EquatorialEarthRadius = 6365631;
            StartLocationInDegrees = new Location();
            EndLocationInDegrees = new Location();
            StartLocationInRadian = new Location();
            EndLocationInRadian = new Location();
        }

        private void GetPositionsValues()
        {
            StartLocationInDegrees.Latitude = ParseStringValueToDouble(StartLatTxtBx.Text);
            StartLocationInDegrees.Longitude = ParseStringValueToDouble(StartLonTxtBx.Text);
            EndLocationInDegrees.Latitude = ParseStringValueToDouble(EndLatTxtBx.Text);
            EndLocationInDegrees.Longitude = ParseStringValueToDouble(EndLonTxtBx.Text);
        }

        private void PostionsToRadians()
        {
            StartLocationInRadian.Latitude = UnitConverter.DegreesToRadians(StartLocationInDegrees.Latitude);
            StartLocationInRadian.Longitude = UnitConverter.DegreesToRadians(StartLocationInDegrees.Longitude);
            EndLocationInRadian.Latitude = UnitConverter.DegreesToRadians(EndLocationInDegrees.Latitude);
            EndLocationInRadian.Longitude = UnitConverter.DegreesToRadians(EndLocationInDegrees.Longitude);
        }

        private void MeasureUsingModifiedPythagorous()
        {
            double lat = EndLocationInDegrees.Latitude - StartLocationInDegrees.Latitude;
            double lon = EndLocationInDegrees.Longitude - StartLocationInDegrees.Longitude;

            double squaredLat = Math.Pow(69.1 * lat,2) ;
            double squaredLon = Math.Pow(53.0 * lon, 2);

            ModifiedPythagorasResult = Math.Sqrt(squaredLat + squaredLon);    
        }

        private void MeasureGreaterCircle()
        {
           
            double sineAngle = Math.Sin(StartLocationInRadian.Latitude) * Math.Sin(EndLocationInRadian.Latitude);
            double cosAngle = Math.Cos(StartLocationInRadian.Latitude) *  Math.Cos(EndLocationInRadian.Latitude) *
                Math.Cos(EndLocationInRadian.Longitude - StartLocationInRadian.Longitude);

            double distanceMetres = EquatorialEarthRadius * Math.Acos(sineAngle + cosAngle);

            GreaterCircleResult = UnitConverter.MetresToMiles(distanceMetres);

        }

        private void MeasureHaversineForumla()
        {
                
            double dlat = EndLocationInRadian.Latitude - StartLocationInRadian.Latitude;
           
            double dlon = EndLocationInRadian.Longitude - StartLocationInRadian.Longitude;

            double squaredSinDlat = Math.Sin(dlat / 2) * Math.Sin(dlat / 2);
         
            double squaredSinLon =  Math.Sin(dlon/2) * Math.Sin(dlon / 2);
           
            double squaredCos = Math.Cos(StartLocationInRadian.Latitude) * Math.Cos(EndLocationInRadian.Latitude);


            double squared = squaredSinDlat + squaredSinLon * squaredCos;
            double distanceMetres = EquatorialEarthRadius * 2 * Math.Asin(Math.Sqrt(squared));
            HaversineFormulaResult = UnitConverter.MetresToMiles(distanceMetres);
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
            StartLocationInDegrees = new Location();
          
        }

        private void ClearEndValuesBtn_Click(object sender, RoutedEventArgs e)
        {
            EndLatTxtBx.Text = "";
            EndLonTxtBx.Text = "";
            EndLocationInDegrees = new Location();
            
        }

        private void ClearResultsValuesBtn_Click(object sender, RoutedEventArgs e)
        {
            ModifiedPythagorousResultTxtBx.Text = "";
            GreaterCircleResultTxtBx.Text = "";
            HaversineFormulaResultTxtBx.Text = "";    
        }

        private void ClearAllBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearStartValuesBtn_Click(this, null);
            ClearEndValuesBtn_Click(this, null);
            ClearResultsValuesBtn_Click(this, null);

        }
    }
}
