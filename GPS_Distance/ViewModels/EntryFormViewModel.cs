using GPS_Distance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace GPS_Distance.ViewModels
{
    //todo constrain the maximum size of the listbox 
    //todo add scrollable to the listbox control

    public class EntryFormViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Location> _endPointLocations;
        private string _startLatitude;
        private string _startLongitude;
        private string _endLatitude;
        private string _endLongitude;

        #endregion

        #region Properties

        public ObservableCollection<Location> EndPointsLocations
        {
            get => _endPointLocations;
            set => SetProperty(ref _endPointLocations, value);
        }

        public string StartLatitude
        {
            get => _startLatitude;
            set => SetProperty(ref _startLatitude, value);
        }

        public string StartLongitude
        {
            get => _startLongitude;
            set => SetProperty(ref _startLongitude, value);
        }

        public string EndLatitude
        {
            get => _endLatitude;
            set => SetProperty(ref _endLatitude, value);
        }

        public string EndLongitude
        {
            get => _endLongitude;
            set => SetProperty(ref _endLongitude, value);
        }

        #endregion

        #region Commands

        public ICommand ClearStartValuesCommand { get; }
        public ICommand ClearEndValuesCommand { get; }
        public ICommand AddEndPointCommand { get; }
        public ICommand ClearEndPositionsListCommand { get; }
        public ICommand ResetFormCommand { get; }
        public ICommand MeasureDistanceCommand { get; }

        #endregion

        #region Constructor

        public EntryFormViewModel()
        {
            EndPointsLocations = new ObservableCollection<Location>();

            // Setup Command
            ClearStartValuesCommand = new RelayCommand(ClearStartValues);
            ClearEndValuesCommand = new RelayCommand(ClearEndValues);
            AddEndPointCommand = new RelayCommand(AddEndPoint);
            ClearEndPositionsListCommand = new RelayCommand(ClearEndPositionsList);
            ResetFormCommand = new RelayCommand(ResetForm);
            MeasureDistanceCommand = new RelayCommand(MeasureDistance);
        }

        #endregion

        #region Methods

        private void ClearStartValues()
        {
            StartLatitude = null;
            StartLongitude = null;
        }

        private void ClearEndValues()
        {
            EndLatitude = null;
            EndLongitude = null;
        }

        private void AddEndPoint()
        {
            var location = new Location()
            {
                Latitude = double.Parse(EndLatitude),
                Longitude = double.Parse(EndLongitude)
            };

            EndPointsLocations.Add(location);
            ClearEndValues();
        }

        private void ClearEndPositionsList()
        {
            EndPointsLocations.Clear();
        }

        private void ResetForm()
        {
            ClearStartValues();
            ClearEndValues();
            ClearEndPositionsList();
        }

        private void MeasureDistance()
        {
            var Startlocation = new Location()
            {
                Latitude = double.Parse(StartLatitude),
                Longitude = double.Parse(StartLongitude)
            };
            //todo iterate through he list of the end points and measure there distance
            //todo pass the values to the result tab
            //todo navigate to the result tab

            throw new NotImplementedException();
        }

        #endregion
    }
}
