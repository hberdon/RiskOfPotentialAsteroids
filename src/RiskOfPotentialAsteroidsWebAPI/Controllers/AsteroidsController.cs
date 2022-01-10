using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiskOfPotentialAsteroidsServices.DOM;
using RiskOfPotentialAsteroidsServices.Services;

namespace RiskOfPotentialAsteroidsWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsteroidsController : ControllerBase
    {
        private readonly ILogger<AsteroidsController> _logger;

        public AsteroidsController(ILogger<AsteroidsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ResponseDto Get(int days)
        {
            using(var _service = new RiskOfPotentialAsteroidsService())
            {
                return _service.GetTopThreePotentialAsteroids(days);
            }
        }
    }
}
