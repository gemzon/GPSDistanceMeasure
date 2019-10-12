using GPS_Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GPS_Distance.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Unit _selectedUnit;

        public event PropertyChangedEventHandler PropertyChanged;

        public Unit SelectedUnit
        {
            get { return _selectedUnit; }
            set
            {
                _selectedUnit = value;
                OnPropertyChanged("SelectedUnit");
            }
        }

        public IEnumerable<Unit> Units
        {
            get
            {
                return Enum.GetValues(typeof(Unit)).Cast<Unit>();
            }
        }

        protected void OnPropertyChanged(string name)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(name));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}