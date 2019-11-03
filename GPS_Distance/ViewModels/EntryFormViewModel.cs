using GPS_Distance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

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
                    ValidateProperty(value, (v) => TryParseLatitude(v, out _), "Not a valid latitude");
            }
        }

        public string StartLongitude
        {
            get => _startLongitude;
            set
            {
                if (SetProperty(ref _startLongitude, value))
                    ValidateProperty(value, (v) => TryParseLongitude(v, out _), "Not a valid longitude");
            }
        }

        public string EndLatitude
        {
            get => _endLatitude;
            set
            {
                if (SetProperty(ref _endLatitude, value))
                    ValidateProperty(value, (v) => TryParseLatitude(v, out _), "Not a valid latitude");
            }
        }

        public string EndLongitude
        {
            get => _endLongitude;
            set
            {
                if (SetProperty(ref _endLongitude, value))
                    ValidateProperty(value, (v) => TryParseLongitude(v, out _), "Not a valid longitude");
            }
        }

        #endregion

        #region Commands

        public ICommand ClearStartValuesCommand { get; }
        public ICommand ClearEndValuesCommand { get; }
        public ICommand AddEndPointCommand { get; }
        public ICommand ClearEndPositionsListCommand { get; }
        public ICommand ResetFormCommand { get; }
        public ICommand MessureDistanceCommand { get; }

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
            MessureDistanceCommand = new RelayCommand(MessureDistance);
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
            if (!TryParseLatitude(EndLatitude, out var latitude))
                return;

            if (!TryParseLongitude(EndLongitude, out var longitude))
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

        private void MessureDistance()
        {
            //todo iterate through he list of the end points and measure there distance
            //todo pass the values to the result tab
            //todo navigate to the result tab

            if (!TryParseLatitude(StartLatitude, out var latitude))
                return;

            if (!TryParseLongitude(StartLongitude, out var longitude))
                return;
        }

        private bool TryParseLatitude(string input, out double latitude)
        {
            var regex = @"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$";
            return TryParseRegexToDouble(input, regex, out latitude);
        }

        private bool TryParseLongitude(string input, out double longitude)
        {
            var regex = @"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$";
            return TryParseRegexToDouble(input, regex, out longitude);
        }

        private bool TryParseRegexToDouble(string input, string regex, out double value)
        {
            var valid = !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, regex);
            value = valid ? double.Parse(input) : 0;

            return valid;
        }

        #endregion
    }
}
