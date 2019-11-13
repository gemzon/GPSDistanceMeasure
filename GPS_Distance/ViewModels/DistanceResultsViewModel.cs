using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GPS_Distance.Helpers;
using GPS_Distance.Models;

namespace GPS_Distance.ViewModels
{
    public class DistanceResultsViewModel : BaseViewModel
    {
        #region Fields

        private MeasurementInputs _measurementInputs;
        private ObservableCollection<Location> _endLocations;
        private string _startLocation;
        private ObservableCollection<DistanceResult> _distanceResult;
        private Unit _selectedUnit;

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

        public Unit SelectedUnit
        {
            get => _selectedUnit;
            set => SetProperty(ref _selectedUnit, value);
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
            MeasurementInputs = new MeasurementInputs(); // NOTE: Where sets Start Locations?
            //MeasurementInputs.StartLocationInRadians = Helper.ConvertStartLocationToRadians(MeasurementInputs.StartLocationInDegrees);
            //MeasurementInputs.EarthRadius = Helper.GetEarthRadius(MeasurementInputs.StartLocationInDegrees.Latitude);
        }

        private void GenreateSourceData() // NOTE: Where is this method called?
        {
            DistanceResult = Helper.MeasureDistance(EndPositions, SelectedUnit, MeasurementInputs);
        }

        private void SetStartLocation()
        {
            StartLocation = $"Start GPS Position Latitude={MeasurementInputs.Latitude},Longitude={MeasurementInputs.Longitude} ";
        }
        #endregion

        //Todo not implmented yet

        public IEnumerable<Unit> Units
        {
            get
            {
                return Enum.GetValues(typeof(Unit)).Cast<Unit>();
            }
        }

    }
}
