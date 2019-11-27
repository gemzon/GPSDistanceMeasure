namespace DistanceCalculator.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MeasurementInputs2
    {
        public MeasurementInputs2(Location start) : this(start.Latitude, start.Longitude) { }
        public MeasurementInputs2(double latitude, double longitude)
        {
            Start = new Location(latitude, longitude);
            Routes = new List<Route>();
        }
        public void AddEndPoint(double latitude, double longitude)
        {
            Routes.Add(new Route(Start, new Location(latitude, longitude)));
        }
        public void AddEndPoints(Collection<Location> locations)
        {
            foreach (var location in locations) AddEndPoint(location.Latitude, location.Longitude);
        }
        public Location Start { get; }
        public List<Route> Routes { get; }
    }
}
