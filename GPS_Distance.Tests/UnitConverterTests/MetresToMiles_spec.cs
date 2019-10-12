using FluentAssertions;
using GPS_Distance.Helpers;
using Xunit;

namespace UnitConverterTests.MetresToMiles_spec
{
    public class Given_boundary_values
    {
        public const double ExpectedPrecision = 0.00000001;

        [Theory]
        [InlineData(-1, -0.0006213712)]
        [InlineData(0, 0)]
        [InlineData(1, 0.0006213712)]
        [InlineData(2, 0.0012427424)]
        [InlineData(1000, 0.62137)]
        public void Should_return_correctly_converted_miles(double meters, double expectedMiles)
        {
            // Act
            var actualMiles = UnitConverter.MetresToMiles(meters);

            // Assert
            actualMiles.Should().BeApproximately(expectedMiles, ExpectedPrecision);
        }
    }
}
