using CTeleportDistanceCalculation.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleportDistanceCalculation.Domain
{
    public static class ServiceExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IDistanceCalculationService), typeof(DistanceCalculationService));
        }
    }
}