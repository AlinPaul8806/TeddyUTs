
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;
        private readonly IDNS _dns;

        public NetworkServiceTests()
        {
            //Dependencies
            _dns = A.Fake<IDNS>();

            //SUT
            _pingService = new NetworkService(_dns);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - variables, classes, mocks
            A.CallTo(() => _dns.SendDns()).Returns(true);

            //Act
            var response = _pingService.SendPing();

            //Assert
            Assert.Equal("Success: Ping Sent!", response);
            //FluenAssertions:
            response.Should().NotBeNullOrEmpty();
            response.Should().Be("Success: Ping Sent!");
            response.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnsInt(int a, int b, int expected)
        {
            //Arrange

            //Act
            var result = _pingService.PingTimeout(a, b);

            //Assert
            expected.Should().BeGreaterThan(0);
            result.Should().Be(expected);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnString()
        {
            //Arrange - variables, classes, mocks

            //Act
            var result = _pingService.LastPingDate();

            //Assert
            //FluenAssertions:
            result.Should().BeAfter(11.June(2026));
            result.Should().BeBefore(13.June(2027));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject()
        {
            //Arrange
            var expectedResult = new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var result = _pingService.GetPingOptions();

            //Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expectedResult);
            result.Ttl.Should().Be(1);
            result.DontFragment.Should().Be(true);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnsObject()
        {
            //Arrange
            List<PingOptions> expectedPings = new()
            {
                    new PingOptions
                {
                    DontFragment = true,
                    Ttl = 1
                },
            };
            var expectedResult = expectedPings;

            //Act
            var result = _pingService.MostRecentPings();

            //Assert
            result.Should().BeAssignableTo<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(new PingOptions { DontFragment = true, Ttl = 1 });
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
