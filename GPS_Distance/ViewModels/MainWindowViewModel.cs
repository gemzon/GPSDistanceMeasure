
using CommonServiceLocator;
using GPS_Distance.Events;
using Prism.Events;
using System;

namespace GPS_Distance.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        private IEventAggregator _eventAggregator;
        public MainWindowViewModel()
        {
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            _eventAggregator.GetEvent<DistanceResultEvent>().Subscribe(args => IsResultTabSelected = true);
        }


        private bool _IsResultTabSelected;

        public bool IsResultTabSelected
        {
            get { return _IsResultTabSelected; }
            set
            {
                _IsResultTabSelected = value;
                OnPropertyChanged();
            }
        }

    }
}
