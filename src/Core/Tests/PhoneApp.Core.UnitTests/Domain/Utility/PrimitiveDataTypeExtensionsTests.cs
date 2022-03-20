using PhoneApp.Core.Domain.Utility;
using PhoneApp.Core.UnitTests.Base;
using Xunit;

namespace PhoneApp.Core.UnitTests.Domain.Utility
{
    public class EventHPrimitiveDataTypeExtensionsTestselperTests : TestBase
    {
        [Fact]
        public void IsNegative_Should_Return_True()
        {
            var value = -1;
            var expected = value.IsNegative();
            Assert.True(expected);
        }
        [Fact]
        public void IsNegative_Should_Return_False()
        {
            var value = 1;
            var expected = value.IsNegative();
            Assert.False(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void IsNegativeOrZero_Should_Return_True(int value)
        {
            var expected = value.IsNegativeOrZero();
            Assert.True(expected);
        }

        [Fact]
        public void IsNegativeOrZero_Should_Return_False()
        {
            var value = 1;
            var expected = value.IsNegativeOrZero();
            Assert.False(expected);
        }
    }
}
