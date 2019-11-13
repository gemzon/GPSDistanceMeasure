using FluentAssertions;
using GPS_Distance.MeasurementFormulas;
using Xunit;

namespace MeasurementFormulasTests.RadiusLatitudeAdjustment_spec
{
    public class Given_some_precondition
    {
        [Theory]                      // NOTE: Relevant test data missing.
        [InlineData(0, 6378137.0)]    // Equatorial radius 6,378.1370 km
        //[InlineData(90, 6356752.3)] // Polar radius 6,356.7523 km 
        public void Should_return_correctly_adjusted_latitude(double actualLatitude, double expectedLatitude)
        {
            // Act
            var actualDistance = RadiusLatitudeAdjustment.LatitudeAdjustment(actualLatitude);

            // Assert
            actualDistance.Should().Be(expectedLatitude);
        }
    }
}

/* https://en.wikipedia.org/wiki/Earth_radius#Published_values

Equatorial radius
The Earth's equatorial radius is the distance from its center to the equator and equals 6,378.1370 km.
The equatorial radius is often used to compare Earth with other planets.

Polar radius
The Earth's polar radius is the distance from its center to the North and South Poles, and equals 6,356.7523 km.
*/
