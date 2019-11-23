using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GPS_Distance.Models
{
    /*
     entire purpose of this class is to transfer the input value for start and end locations 
       from the entry for to what ever class is listening to the event handler 
     */
    public class InputDTO
    {
        public  ObservableCollection<InputLocation> EndLocations { get; set; }
        public  InputLocation StartLocation { get; set; }
                
    }
}
