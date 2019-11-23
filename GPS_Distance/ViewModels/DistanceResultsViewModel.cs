using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommonServiceLocator;
using GPS_Distance.Events;
using GPS_Distance.Models;
using Prism.Events;
using static GPS_Distance.Helpers.Helper;

namespace GPS_Distance.ViewModels
{
    public class DistanceResultsViewModel : BaseViewModel
    {
        #region Fields

        private MeasurementInputs _measurementInputs = new MeasurementInputs();
        private List<Location> _endLocations = new List<Location>();
        private Unit _selectedUnit = Unit.Miles;
        private ObservableCollection<DistanceResult> _distanceResults = new ObservableCollection<DistanceResult>();
        private IEventAggregator _eventAggregator;

        #endregion

        #region Properties
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
        public ObservableCollection<DistanceResult> DistanceResults
        {
            get => _distanceResults;
            set => SetProperty(ref _distanceResults, value);
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
        }

        private void DistanceResultEventHandler(DistanceResultEventArgs obj)
        {
            MeasurementInputs = new MeasurementInputs(
                new Location(obj.InputDTO.StartLocation.Latitude, obj.InputDTO.StartLocation.Longitude));

            EndPositions.AddRange(obj.InputDTO.EndLocations.Select(inputLocation
                => new Location(inputLocation.Latitude, inputLocation.Longitude)));
            GenerateSourceData();
        }
        #endregion

        #region Methods
        private void GenerateSourceData()
        {
            DistanceResults = MeasureDistance(MeasurementInputs, EndPositions, SelectedUnit);
        }
        #endregion
    }
}
