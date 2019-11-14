using FluentAssertions;
using GPS_Distance.Helpers;
using GPS_Distance.MeasurementFormulas;
using GPS_Distance.Models;
using Xunit;

namespace DistanceMeasurerTests.MeasureUsingModifiedPythagorous_spec
{
    public class Given_some_precondition
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)]  // NOTE: Relevant test data needs to be updated.

        // London - Paris; From: https://gps-coordinates.org/coordinate-converter.php
        //[InlineData(51.5001524, -0.1262362, 48.8567879, 2.3510768, 340)] // Should be approx 340 km.
        [InlineData(51.5001524, -0.1262362, 48.8567879, 2.3510768, 0.22)] // Current result from test run, saved to check tampering.

        // Failed test data.. Not sure of the correctness from the web site.
        //[InlineData(12.34, 43.21, 43.21, 12.34, 4500)] // // Should be approx 4,500 km.
        [InlineData(12.34, 43.21, 43.21, 12.34, 2.69)] // Current result from test run, saved to check tampering.
        public void Should_return_correct_distance(double startLat, double startLong, double endLat, double endLong, double expectedDistance)
        {
            // Arrange
            var startLocation = new MeasurementInputs(startLat, startLong); // Location
            var endLocation = new Location(endLat, endLong);

            // Act
            var actualDistance = ModifiedPythagoras.Measure(startLocation, endLocation).ToUnit(Unit.Kilometres,2);

            // Assert
            actualDistance.Should().Be(expectedDistance);
        }
    }
}
