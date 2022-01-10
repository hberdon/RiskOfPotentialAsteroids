using RiskOfPotentialAsteroids.DOM;
using System;
using System.Collections.Generic;

namespace RiskOfPotentialAsteroidsServices.DOM
{
    [Serializable]
    public class ResponseDto
    {
        public IEnumerable<AsteroidDto> asteroids { get; set; }

        public string message { get; set; }
    }
}
