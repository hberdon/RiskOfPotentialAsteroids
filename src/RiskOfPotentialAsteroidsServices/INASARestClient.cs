using RiskOfPotentialAsteroids.DOM;

namespace RiskOfPotentialAsteroidsServices.Services
{
    public interface INASARestClient
    {
        Asteroid[] GetRiskAsteroids(int days);
    }
}
