using FluentAssertions;
using GPS_Distance.Helpers;
using Xunit;

namespace GPS_Distance.Tests
{
    public class Various
    {
        [Theory]
        [InlineData(0.1004111, "0,1004")]
        [InlineData(0.1004500, "0,1004")]
        [InlineData(0.1004999, "0,1005")]
        [InlineData(0.1005111, "0,1005")]
        [InlineData(0.1005500, "0,1006")]
        [InlineData(0.1005999, "0,1006")]
        public void Test1(double value, string expectedOutput)
        {
            var v1 = Helper.FormatDouble(value);
            var actualOutput1 = v1.ToString();

            actualOutput1.Should().Be(expectedOutput);

            var v2 = value;
            var actualOutput2 = v2.ToUnit(Models.Unit.Metres).ToString();

            actualOutput2.Should().Be(expectedOutput);

            actualOutput2.Should().Be(actualOutput1);
        }
    }
}
