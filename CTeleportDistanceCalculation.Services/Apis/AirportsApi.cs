using CTeleportDistanceCalculation.Data.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace CTeleportDistanceCalculation.Data.Apis
{
    public class AirportsApi : IAirportsApi
    {
        public async Task<Airport> GetAirportInfoAsync(string iataCode)
        {
            Airport airportInfo;

            var apiUrl = GetApiUrl();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{apiUrl}{iataCode.ToUpper()}"))
                {
                    response.EnsureSuccessStatusCode();
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    airportInfo = JsonConvert.DeserializeObject<Airport>(apiResponse);
                }
            }

            return airportInfo;
        }

        private string GetApiUrl()
        {
            var url = LibrarySettings.AppSettings["APIUrl"];
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ConfigurationErrorsException("No api URL in config");
            }
            return url;
        }
    }
}