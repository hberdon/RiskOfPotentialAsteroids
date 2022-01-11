using AutoMapper;
using RiskOfPotentialAsteroids.DOM;
using RiskOfPotentialAsteroidsServices.DOM;
using System;
using System.Linq;

namespace RiskOfPotentialAsteroidsServices.Services
{
    public class RiskOfPotentialAsteroidsService : IRiskOfPotentialAsteroidsService, IDisposable
    {
        /// <summary>
        ///     Get top three biggest potential asteroids by date between today and next days based on parameters days
        /// </summary>
        /// <param name="days">Number of days from today</param>
        /// <returns></returns>
        public ResponseDto GetTopThreePotentialAsteroids(int days)
        {
            try
            {
                //Initialize the mapper
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Asteroid, AsteroidDto>()
                    .ForMember(dest => dest.Diametro, act => act.MapFrom(src => src.estimated_diameter.kilometers.estimated_diameter_average))
                    .ForMember(dest => dest.Fecha, act => act.MapFrom(src => src.close_approach_data[0].close_approach_date))
                    .ForMember(dest => dest.Nombre, act => act.MapFrom(src => src.name))
                    .ForMember(dest => dest.Planeta, act => act.MapFrom(src => src.close_approach_data[0].orbiting_body))
                    .ForMember(dest => dest.Velocidad, act => act.MapFrom(src => src.close_approach_data[0].relative_velocity.kilometers_per_hour))
                    );

                var mapper = new Mapper(config);

                using (var restClient = new NASARestClient())
                {
                    var asteroids = restClient.GetRiskAsteroids(days);

                    var list = (from asteroid in asteroids
                                where asteroid.is_potentially_hazardous_asteroid == true
                                orderby asteroid.estimated_diameter.kilometers.estimated_diameter_average descending
                                select asteroid).Take(3);

                    return new ResponseDto
                    {
                        asteroids = mapper.Map<AsteroidDto[]>(list),
                        message = $"Found {list.Count()} risk potential asteroids."
                    };
                }
            }
            catch(Exception ex)
            {
                return new ResponseDto
                {
                    message = ex.Message
                };
            }
        }

        public void Dispose()
        {
        }
    }
}
