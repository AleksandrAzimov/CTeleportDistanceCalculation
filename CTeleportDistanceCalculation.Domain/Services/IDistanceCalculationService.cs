using CTeleportDistanceCalculation.Domain.Responses;
using CTeleportDistanceCalculation.Domain.ViewModels;
using System.Threading.Tasks;

namespace CTeleportDistanceCalculation.Domain.Services
{
    public interface IDistanceCalculationService
    {
        Task<Response<DistanceResponseVM>> GetDistanceAsync(DistanceRequestVM request);
    }
}