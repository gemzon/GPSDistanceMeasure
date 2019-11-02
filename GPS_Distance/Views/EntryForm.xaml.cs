using GPS_Distance.Models;
using GPS_Distance.ViewModels;
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
    /// Interaction logic for EntryForm.xaml
    /// </summary>
    public partial class EntryForm : UserControl
    {
        //todo constrain the maximum size of the listbox 
        //todo add scrollable to the listbox control


        private EntryFormViewModel vm  = new EntryFormViewModel();
        public EntryForm()
        {
             InitializeComponent();
           
            vm.EndPointsLocations = new ObservableCollection<Location> ();
            DataContext = vm;
            EndGPSPointsListBox.ItemsSource = vm.EndPointsLocations;
            
        }
        private void MeasureDistanceBtn_Click(object sender, RoutedEventArgs e)
        {
            //todo iterate through he list of the end points and measure there distance
            //todo pass the values to the result tab
            //todo navigate to the result tab
        }

        private void AddEndPointBtn_Click(object sender, RoutedEventArgs e)
        {
           //Todo clear endpoint entry boxes

            var location = new Location() {
                Latitude = double.Parse(EndLatTxtBx.Text),
                Longitude = double.Parse(EndLonTxtBx.Text)
            };

            try
            {
    vm.EndPointsLocations.Add(location); 
            }
            catch (Exception ex )
            {

                Console.WriteLine(ex); 
            }
        
          

        }

        #region clearvalues
        private void ClearStartValuesBtn_Click(object sender, RoutedEventArgs e)
        {
            StartLatTxtBx.Text = "";
            StartLonTxtBx.Text = "";
        }

        private void ClearEndValuesBtn_Click(object sender, RoutedEventArgs e)
        {
            EndLatTxtBx.Text = "";
            EndLonTxtBx.Text = "";
        }

        private void ClearEndGPSListBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO reset List of end point

        }



        private void ClearAllBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearStartValuesBtn_Click(this, e);
            ClearEndValuesBtn_Click(this, e);
            ClearEndGPSListBtn_Click(this, e);
        }

        #endregion clearvalues  

    }
}
