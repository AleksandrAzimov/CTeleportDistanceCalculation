using CTeleportDistanceCalculation.Data.Models;
using System.Threading.Tasks;

namespace CTeleportDistanceCalculation.Data.Apis
{
    public interface IAirportsApi
    {
        Task<Airport> GetAirportInfoAsync(string iataCode);
    }
}