using GPS_Distance.Helpers;
using GPS_Distance.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace GPS_Distance.ViewModels
{
    public class DistanceResultsViewModel : BaseViewModel
    {


        #region Fields

        private MeasurementInputs _measurementInputs;
        private ObservableCollection<Location> _endLocations;
        private string _startLocation;
        private ObservableCollection<DistanceResult> _distanceResult;
        private Unit _unit;
        #endregion

        #region Properties
        public ObservableCollection<DistanceResult> DistanceResult
        {
            get => _distanceResult;
            set => SetProperty(ref _distanceResult, value);
        }

        public string StartLocation
        {
            get => _startLocation;
            set => SetProperty(ref _startLocation, value);
        }

        public MeasurementInputs MeasurementInputs
        {
            get => _measurementInputs;
            set => SetProperty(ref _measurementInputs, value);
        }

        public ObservableCollection<Location> EndPositions
        {
            get => _endLocations;
            set => SetProperty(ref _endLocations, value);
        }

        public Unit Unit
        {
            get => _unit;
            set => SetProperty(ref _unit, value);
        }
        #endregion


        #region Commands
        public ICommand GenerateSourceDataCommand { get; }
        #endregion

        #region Constructor
        public DistanceResultsViewModel()
        {
            GenerateSourceDataCommand = new RelayCommand(GenreateSourceData);
            SetMeasurmentInputs();
            SetStartLocation();

        }


        #endregion

        #region Methods
        private void SetMeasurmentInputs()
        {
            MeasurementInputs = new MeasurementInputs();
            MeasurementInputs.StartLocationInRadians = MeasureDistanceHelper.ConvertStartLocationToRadians(MeasurementInputs.StartLocationInDegrees);
            MeasurementInputs.EarthRadius = MeasureDistanceHelper.GetEarthRadius(MeasurementInputs.StartLocationInDegrees.Latitude);
        }

        private void GenreateSourceData()
        {
            DistanceResult = MeasureDistanceHelper.MeasureDistance(EndPositions, Unit, MeasurementInputs);
        }

        private void SetStartLocation()
        {
            StartLocation = $"Start GPS Position Latitude={MeasurementInputs.StartLocationInDegrees.Latitude},Longitude={MeasurementInputs.StartLocationInDegrees.Longitude} ";

        }
        #endregion  
    }
}
