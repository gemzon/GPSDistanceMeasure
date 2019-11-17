using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS_Distance.Events
{
    internal class DistanceResultEvent : PubSubEvent<DistanceResultEventArgs>
    {
    }

    public class DistanceResultEventArgs
    {
        public int SomeData { get; set; }
    }

}
