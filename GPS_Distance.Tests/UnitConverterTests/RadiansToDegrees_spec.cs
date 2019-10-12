using FluentAssertions;
using GPS_Distance.Helpers;
using Xunit;

namespace UnitConverterTests.RadiansToDegrees_spec
{
    public class Given_boundary_values
    {
        public const double ExpectedPrecision = double.Epsilon;

        [Theory]
        [InlineData(-1, -180)]
        [InlineData(1, 180)]
        [InlineData(2, 360)]
        public void Should_return_correctly_converted_degrees(double radian, double expectedDegrees)
        {
            // Act
            var actualDegrees = UnitConverter.RadiansToDegrees(radian);

            // Assert
            actualDegrees.Should().BeApproximately(expectedDegrees, ExpectedPrecision);
        }
    }

    public class Given_zero_radian
    {
        [Fact]
        public void Should_return_positive_infinite()
        {
            // Arrange
            double radian = 0;

            // Act
            var actualDegrees = UnitConverter.RadiansToDegrees(radian);

            // Assert
            actualDegrees.Should().Be(double.PositiveInfinity);
        }
    }
}
