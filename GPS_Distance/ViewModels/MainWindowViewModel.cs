using System;
using System.Collections.Generic;
using System.Text;

namespace GPS_Distance.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //TabControl TabItem Index
        private int _selectedIdx;

        public int SelectedIdx
        {
            get => _selectedIdx;
            set => SetProperty(ref _selectedIdx, value);
        }

    }
}
