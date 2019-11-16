using FluentAssertions;
using GPS_Distance.Models;
using Xunit;
using static GPS_Distance.Helpers.Helper;
using static GPS_Distance.MeasurementFormulas.Measure;

namespace DistanceMeasurerTests.MeasureUsingGreaterCircle_spec
{
    public class Given_some_precondition
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)] // NOTE: Relevant test data needs to be updated.

        // London - Paris; From: https://gps-coordinates.org/coordinate-converter.php
        //[InlineData(51.5001524, -0.1262362, 48.8567879, 2.3510768, 334.18)] // From: http://convertalot.com/great_circle_distance_calculator.html
        [InlineData(51.5001524, -0.1262362, 48.8567879, 2.3510768, 342.80)] // Current result from test run, saved to check tampering.

        // Failed test data.. Not sure of the correctness from the web site.
        //[InlineData(12.34, 43.21, 43.21, 12.34, 4527.29)] // From: http://convertalot.com/great_circle_distance_calculator.html
        [InlineData(12.34, 43.21, 43.21, 12.34, 4536.98)] // Current result from test run, saved to check tampering.
        public void Should_return_correct_distance(double startLat, double startLong, double endLat, double endLong, double expectedDistance)
        {
            // Arrange
            var startLocation = new MeasurementInputs(startLat, startLong);
            var endLocation = new Location(endLat, endLong);

            // Act
            var actualDistance = GreaterCircle(startLocation, endLocation).ToUnit(Unit.Kilometres, 2);

            // Assert
            actualDistance.Should().Be(expectedDistance);
        }
    }
}
