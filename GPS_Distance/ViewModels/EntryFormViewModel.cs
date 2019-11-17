using System.Collections.ObjectModel;
using System.Windows.Input;
using CommonServiceLocator;
using GPS_Distance.Events;
using GPS_Distance.Models;
using Prism.Events;
using static GPS_Distance.Helpers.Helper;

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
        private IEventAggregator _eventAggregator;

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
        public ICommand MeasureDistanceCommand { get; }

        #endregion

        #region Constructor

        public EntryFormViewModel()
        {
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

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
            if (!TryParseLatitude(EndLatitude, out var latitude)) return;
            if (!TryParseLongitude(EndLongitude, out var longitude)) return;

            EndPointsLocations.Add(new Location(latitude, longitude));
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
            if (!TryParseLatitude(StartLatitude, out var latitude)) return;
            if (!TryParseLongitude(StartLongitude, out var longitude)) return;

            var Startlocation = new Location(latitude, longitude);

            //todo iterate through he list of the end points and measure there distance
            //todo pass the values to the result tab
            //todo navigate to the result tab

            _eventAggregator.GetEvent<DistanceResultEvent>().Publish(new DistanceResultEventArgs { SomeData = 123 });
        }

        #endregion
    }
}
