using GPS_Distance.Helpers;
using GPS_Distance.MeasurementFormulas;
using GPS_Distance.Models;
using GPS_Distance.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace GPS_Distance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double EarthRadius;
        public Location StartLocationInDegrees;
        public Location StartLocationInRadian;
        public Location EndLocationInDegrees;
        public Location EndLocationInRadian;

        private MainWindowViewModel vm = new MainWindowViewModel();

        public MainWindow()
        {
            vm.PropertyChanged += ReturnMeasurementValues;

            DataContext = vm;

            StartLocationInDegrees = new Location();
            EndLocationInDegrees = new Location();
            StartLocationInRadian = new Location();
            EndLocationInRadian = new Location();

            InitializeComponent();
        }

        private void MeasureDistanceBtn_Click(object sender, RoutedEventArgs e)
        {
            InitilizeVariables();
            ReturnMeasurementValues(sender, null);
        }

        private void InitilizeVariables()
        {
            GetPositionsValues();
            StartLocationInRadian = PositionToRadians.ConvertToRadians(StartLocationInDegrees);
            EndLocationInRadian = PositionToRadians.ConvertToRadians(EndLocationInDegrees);
            EarthRadius = RadiusLatitudeAdjustment.LatitudeAdjustment(StartLocationInDegrees.Latitude);
        }

        private void ReturnMeasurementValues(object sender, PropertyChangedEventArgs e)
        {
            ModifiedPythagorousResultTxtBx.Text = ModifiedPythagoras.Measure(StartLocationInDegrees, EndLocationInDegrees, vm.SelectedUnit).ToString();
            GreaterCircleResultTxtBx.Text = GreaterCircle.Measure(StartLocationInRadian, EndLocationInRadian, EarthRadius, vm.SelectedUnit).ToString();
            HaversineFormulaResultTxtBx.Text = HaversineFormula.Measure(StartLocationInRadian, EndLocationInRadian, EarthRadius, vm.SelectedUnit).ToString();
        }

        private void GetPositionsValues()
        {
            StartLocationInDegrees.Latitude = double.Parse(StartLatTxtBx.Text);
            StartLocationInDegrees.Longitude = double.Parse(StartLonTxtBx.Text);
            EndLocationInDegrees.Latitude = double.Parse(EndLatTxtBx.Text);
            EndLocationInDegrees.Longitude = double.Parse(EndLonTxtBx.Text);
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