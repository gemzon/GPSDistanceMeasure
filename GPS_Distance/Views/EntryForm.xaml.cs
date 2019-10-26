using System;
using System.Collections.Generic;
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
    public partial class EntryForm : Page
    {
        public EntryForm()
        {
            InitializeComponent();
        }
        private void MeasureDistanceBtn_Click(object sender, RoutedEventArgs e)
        {
            //todo iterate through he list of the end points and measure there distance
            //todo pass the values to the result tab
            //todo navigate to the result tab
        }

        private void AddEndPointBtn_Click(object sender, RoutedEventArgs e)
        {
            //Todo add end point to List of end points
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
