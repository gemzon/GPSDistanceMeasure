﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using GPS_Distance.Helpers;
using GPS_Distance.Models;

namespace GPS_Distance.ViewModels
{
    //todo constrain the maximum size of the listbox 
    //todo add scrollable to the listbox control

    public class EntryFormViewModel : ValidationBaseViewModel
    {
        #region Fields

        private ObservableCollection<Location> _endPointLocations;
        private string _startLatitude = "0";
        private string _startLongitude = "0";
        private string _endLatitude = "0";
        private string _endLongitude = "0";

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
            set
            {
                if (SetProperty(ref _startLatitude, value))
                    ValidateProperty(value, (v) => Helper.TryParseLatitude(v, out _), "Not a valid latitude");
            }
        }

        public string StartLongitude
        {
            get => _startLongitude;
            set
            {
                if (SetProperty(ref _startLongitude, value))
                    ValidateProperty(value, (v) => Helper.TryParseLongitude(v, out _), "Not a valid longitude");
            }
        }

        public string EndLatitude
        {
            get => _endLatitude;
            set
            {
                if (SetProperty(ref _endLatitude, value))
                    ValidateProperty(value, (v) => Helper.TryParseLatitude(v, out _), "Not a valid latitude");
            }
        }

        public string EndLongitude
        {
            get => _endLongitude;
            set
            {
                if (SetProperty(ref _endLongitude, value))
                    ValidateProperty(value, (v) => Helper.TryParseLongitude(v, out _), "Not a valid longitude");
            }
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
            StartLatitude = "0";
            StartLongitude = "0";
        }

        private void ClearEndValues()
        {
            EndLatitude = "0";
            EndLongitude = "0";
        }

        private void AddEndPoint()
        {
            if (!Helper.TryParseLatitude(EndLatitude, out var latitude))
                return;

            if (!Helper.TryParseLongitude(EndLongitude, out var longitude))
                return;

            var location = new Location()
            {
                Latitude = latitude,
                Longitude = longitude
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

            if (!Helpers.Helper.TryParseLatitude(StartLatitude, out var latitude))
                return;

            if (!Helpers.Helper.TryParseLongitude(StartLongitude, out var longitude))
                return;
        }

        #endregion
    }
}
