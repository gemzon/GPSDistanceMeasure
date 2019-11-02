using GPS_Distance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GPS_Distance.ViewModels
{
    public class EntryFormViewModel : BaseViewModel
    {  
        private ObservableCollection<Location> endPointLocations;

        public ObservableCollection<Location> EndPointsLocations
        {
            get { return endPointLocations; }
            set { SetProperty(ref endPointLocations, value); }
        }
       
      

    }
}
