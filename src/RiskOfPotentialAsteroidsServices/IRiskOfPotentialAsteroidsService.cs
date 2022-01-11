using RiskOfPotentialAsteroidsServices.DOM;

namespace RiskOfPotentialAsteroidsServices.Services
{
    public interface IRiskOfPotentialAsteroidsService
    {
        ResponseDto GetTopThreePotentialAsteroids(int days);
    }
}
