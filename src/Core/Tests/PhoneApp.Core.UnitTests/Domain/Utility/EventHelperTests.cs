using PhoneApp.Core.Domain.Utility;
using PhoneApp.Core.UnitTests.Base;
using Xunit;

namespace PhoneApp.Core.UnitTests.Domain.Utility
{
    public class EventHelperTests : TestBase
    {
        [Fact]
        public void ToInt_Should_Be_Successful()
        {
            var actual = "amqp://guest:guest@localhost:5672/";
            var expected = EventHelper.BuildRabbitMQUri(
                            "amqp",
                            "guest",
                            "guest",
                            "localhost",
                            5672);
            Assert.Equal(actual, expected.ToString());
        }
    }
}
