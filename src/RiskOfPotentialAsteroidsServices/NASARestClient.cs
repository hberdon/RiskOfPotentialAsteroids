using RiskOfPotentialAsteroids.DOM;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RiskOfPotentialAsteroidsServices.Services
{
    public class NASARestClient : INASARestClient, IDisposable
    {
        private const string api_uri = "https://api.nasa.gov/neo/rest/v1/feed";
        private const string api_key = "zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";

        /// <summary>
        ///     Get list of potential asteroids from NASA API 
        /// </summary>
        /// <param name="days">number of days</param>
        /// <returns></returns>
        public Asteroid[] GetRiskAsteroids(int days)
        {
            List<Asteroid> asteroids = new List<Asteroid>();
            DateTime dt = DateTime.Now.AddDays(days);

            string urlParameters =
                "?start_date=" + DateTime.Now.ToString("yyyy-MM-dd") +
                "&end_date=" + DateTime.Now.AddDays(days).ToString("yyyy-MM-dd") +
                "&api_key=" + api_key;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(api_uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    var nasaResponse = response.Content.ReadAsAsync<NASAResponse>().Result;
                    foreach (var d in nasaResponse.near_earth_objects) asteroids.AddRange(d.Value);
                }
                else
                {
                    throw new Exception($"Error. Reason: {response.StatusCode.ToString()} ({(int)response.StatusCode})");
                }
            }
            return asteroids.ToArray();
        }

        public void Dispose()
        {
        }
    }
}
