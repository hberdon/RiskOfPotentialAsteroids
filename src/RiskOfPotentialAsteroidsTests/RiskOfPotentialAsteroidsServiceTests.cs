using NUnit.Framework;
using RiskOfPotentialAsteroidsServices.Services;
using System.Linq;

namespace RiskOfPotentialAsteroidsTests
{
    public class Tests
    {
        private RiskOfPotentialAsteroidsService _service;

        [SetUp]
        public void Setup()
        {
            _service = new RiskOfPotentialAsteroidsService();
        }

        [Test]
        public void GetAsteroids()
        {
            var result = _service.GetTopThreePotentialAsteroids(5);
            Assert.IsTrue(result.asteroids.Count() > 0) ;
        }
    }
}