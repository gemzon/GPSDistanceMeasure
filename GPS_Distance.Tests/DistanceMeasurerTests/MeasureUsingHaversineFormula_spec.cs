using FluentAssertions;
using GPS_Distance.MeasurementFormulas;
using GPS_Distance.Models;
using Xunit;

namespace DistanceMeasurerTests.HaversineFormula_spec
{
    public class Given_some_precondition
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)] // NOTE: Relevant test data missing.
        public void Should_return_correct_distance(double startLat, double startLong, double endLat, double endLong, double expectedDistance)
        {
            // Arrange
            var startLocation = new MeasurementInputs(startLat, startLong);
            var endLocation = new Location(endLat, endLong);

            // Act
            var actualDistance = HaversineFormula.Measure(startLocation, endLocation);

            // Assert
            actualDistance.Should().Be(expectedDistance);
        }
    }
}
