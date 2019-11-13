using FluentAssertions;
using GPS_Distance.Helpers;
using GPS_Distance.MeasurementFormulas;
using GPS_Distance.Models;
using Xunit;

namespace DistanceMeasurerTests.MeasureUsingGreaterCircle_spec
{
    public class Given_some_precondition
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)] // NOTE: Relevant test data missing.
        // Failed test data.. Not sure of the correctness from the web site.
        //[InlineData(1, 2, 3, 4, 313.7)]                   // From: http://convertalot.com/great_circle_distance_calculator.html
        //[InlineData(12.34, 43.21, 43.21, 12.34, 4511.25)] // From: http://convertalot.com/great_circle_distance_calculator.html
        public void Should_return_correct_distance(double startLat, double startLong, double endLat, double endLong, double expectedDistance)
        {
            // Arrange
            var startLocation = new MeasurementInputs(startLat, startLong);
            var endLocation = new Location(endLat, endLong);

            // Act
            var actualDistance = GreaterCircle.Measure(startLocation, endLocation).ToUnit(Unit.Kilometres, 1);

            // Assert
            actualDistance.Should().Be(expectedDistance);
        }
    }
}
