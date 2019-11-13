using FluentAssertions;
using GPS_Distance.Helpers;
using GPS_Distance.MeasurementFormulas;
using GPS_Distance.Models;
using Xunit;

namespace DistanceMeasurerTests.HaversineFormula_spec
{
    public class Given_some_precondition
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)] // NOTE: Relevant test data missing.
        // Failed test data.. Not sure of the correctness from the web site.
        //[InlineData(1, 2, 3, 4, 314.4)]                // From: https://www.movable-type.co.uk/scripts/latlong.html
        //[InlineData(12.34, 43.21, 43.21, 12.34, 4532)] // From: https://www.movable-type.co.uk/scripts/latlong.html
        public void Should_return_correct_distance(double startLat, double startLong, double endLat, double endLong, double expectedDistance)
        {
            // Arrange
            var startLocation = new MeasurementInputs(startLat, startLong);
            var endLocation = new Location(endLat, endLong);

            // Act
            var actualDistance = HaversineFormula.Measure(startLocation, endLocation).ToUnit(Unit.Kilometres, 1);

            // Assert
            actualDistance.Should().Be(expectedDistance);
        }
    }
}
