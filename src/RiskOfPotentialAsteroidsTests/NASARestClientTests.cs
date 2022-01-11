using Moq;
using NUnit.Framework;
using RiskOfPotentialAsteroids.DOM;
using RiskOfPotentialAsteroidsServices.Services;
using System.Linq;

namespace RiskOfPotentialAsteroidsTests
{
    public class NASARestClientTests
    {
        private INASARestClient _iface;

        [SetUp]
        public void Setup()
        {
            _iface = new NASARestClient();
        }

        [Test]
        public void GetAsteroids()
        {
            var result = _iface.GetRiskAsteroids(5);
            Assert.IsTrue(result.Count() > 0);
        }

        [Test]
        public void MockEmptyList()
        {
            Asteroid[] emptyList = new Asteroid[0];

            var mock = new Mock<INASARestClient>();
            mock.Setup(m => m.GetRiskAsteroids(It.IsAny<int>())).Returns(emptyList);
            var _mockNASARestClient = mock.Object;

            var result = _mockNASARestClient.GetRiskAsteroids(5);
            Assert.IsTrue(result.Count() == 0);
        }
    }
}
