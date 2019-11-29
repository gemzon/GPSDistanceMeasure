namespace GPS_Distance.ViewModels
{
    using CommonServiceLocator;
    using GPS_Distance.Events;
    using Prism.Events;

    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        public MainWindowViewModel()
        {
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            _eventAggregator.GetEvent<DistanceResultEvent>().Subscribe(args => IsResultTabSelected = true);
        }

        private bool _isResultTabSelected;
        public bool IsResultTabSelected
        {
            get => _isResultTabSelected;
            set
            {
                _isResultTabSelected = value;
                OnPropertyChanged();
            }
        }
    }
}
