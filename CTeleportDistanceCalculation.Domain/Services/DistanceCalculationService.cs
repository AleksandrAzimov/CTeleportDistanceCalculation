using AutoMapper;
using CTeleportDistanceCalculation.Data.Apis;
using CTeleportDistanceCalculation.Domain.Extensions;
using CTeleportDistanceCalculation.Domain.Models;
using CTeleportDistanceCalculation.Domain.Responses;
using CTeleportDistanceCalculation.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CTeleportDistanceCalculation.Domain.Services
{
    public class DistanceCalculationService : IDistanceCalculationService
    {
        private readonly IAirportsApi _airpotsApi;
        private readonly IMapper _mapper;
        private readonly ILogger<DistanceCalculationService> _logger;

        public DistanceCalculationService(IAirportsApi airpotsApi, IMapper mapper, ILogger<DistanceCalculationService> logger)
        {
            _airpotsApi = airpotsApi;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<DistanceResponseVM>> GetDistanceAsync(DistanceRequestVM request)
        {
            try
            {
                var airportFromInfo = await _airpotsApi.GetAirportInfoAsync(request.IataCodeFrom);
                var airportToInfo = await _airpotsApi.GetAirportInfoAsync(request.IataCodeTo);

                var fromCoords = _mapper.Map<Coordinates>(airportFromInfo);
                var toCoords = _mapper.Map<Coordinates>(airportToInfo);

                var distance = fromCoords.DistanceTo(toCoords);
                var vm = new DistanceResponseVM() { Distance = distance };

                var response = Response<DistanceResponseVM>.Success(vm);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while calculating distance");
                var response = Response<DistanceResponseVM>.Error("Unable to get airport information");
                return response;
            }
        }
    }
}