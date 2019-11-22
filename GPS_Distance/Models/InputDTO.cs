using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GPS_Distance.Models
{
    public class InputDTO
    {
        public  ObservableCollection<InputLocation> EndLocations { get; set; }
        public  InputLocation StartLocation { get; set; }
                
    }
}
