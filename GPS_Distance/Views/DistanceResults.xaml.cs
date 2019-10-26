using GPS_Distance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPS_Distance.Views
{
    /// <summary>
    /// Interaction logic for DistanceResults.xaml
    /// </summary>
    public partial class DistanceResults : Page
    {
        //Todo replace string with a collection or a new class for results
        public ObservableCollection<string> DistanceResultsList { get; set; }

        public DistanceResults()
        {
            InitializeComponent();
        }

        private void CreateStartLabelText(Location startLocation)
        {
            StartGPS.Content = $"Start GPS Position Latitude={startLocation.Latitude},Longitude={startLocation.Latitude} ";

        }

        //Todo create the distancResultList and bind it to the ResultListView
        //Todo handle the unit change for the ResultLisview
        //Todo add sorting to each of the measurement result columns

    }
}
