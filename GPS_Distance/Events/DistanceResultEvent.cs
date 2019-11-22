using GPS_Distance.Models;
using Prism.Events;
using System;

namespace GPS_Distance.Events
{
    internal class DistanceResultEvent : PubSubEvent<DistanceResultEventArgs>
    {
    }

    public class DistanceResultEventArgs
    {
        public InputDTO? InputDTO { get; set; }
    }

}
