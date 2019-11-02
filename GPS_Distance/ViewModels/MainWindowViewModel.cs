using GPS_Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GPS_Distance.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Unit _selectedUnit;

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

       
    }
}