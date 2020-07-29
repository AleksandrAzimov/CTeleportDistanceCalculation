using CTeleportDistanceCalculation.Data.Apis;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleportDistanceCalculation.Data
{
    public static class ServiceExtensions
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAirportsApi), typeof(AirportsApi));
        }
    }
}