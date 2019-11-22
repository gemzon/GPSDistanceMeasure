using CommonServiceLocator;
using GPS_Distance.Events;
using GPS_Distance.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using static GPS_Distance.Helpers.Helper;

namespace GPS_Distance.ViewModels
{
    public class DistanceResultsViewModel : BaseViewModel
    {
        #region Fields
    
        private MeasurementInputs _measurementInputs = new MeasurementInputs();
        private List<Location> _endLocations = new List<Location>();
        private string _startLocation = string.Empty;
        private ObservableCollection<DistanceResult> _distanceResult = new ObservableCollection<DistanceResult>();
        private Unit _selectedUnit = Unit.Miles;
        private IEventAggregator _eventAggregator;

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

        public List<Location> EndPositions
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
            //TODO Bind list of endpoint to the listview

            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            _eventAggregator.GetEvent<DistanceResultEvent>().Subscribe(DistanceResultEventHandler);
            GenerateSourceDataCommand = new RelayCommand(GenerateSourceData);

            SetMeasurmentInputs();
            SetStartLocation();

        }

        private void DistanceResultEventHandler(DistanceResultEventArgs obj)
        {
            //TODO loop through the list of values coming in and assign them to new locations
            //Set All fields coming from the obj that matters to your view.
        }
        #endregion

        #region Methods
        private void SetMeasurmentInputs()
        {
            MeasurementInputs = new MeasurementInputs();
        }



        private void GenerateSourceData()
        {
            DistanceResult = MeasureDistance(EndPositions, SelectedUnit, MeasurementInputs);
        }

        private void SetStartLocation()
        {
            StartLocation = $"Start GPS Position Latitude={MeasurementInputs.Latitude},Longitude={MeasurementInputs.Longitude} ";
        }
        #endregion



    }
}
