using CTeleportDistanceCalculation.Domain.Responses;
using CTeleportDistanceCalculation.Domain.Services;
using CTeleportDistanceCalculation.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTeleportDistanceCalculation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateDistanceController : ControllerBase
    {
        private readonly ILogger<CalculateDistanceController> _logger;
        private readonly IDistanceCalculationService _distanceCalculationService;

        public CalculateDistanceController(ILogger<CalculateDistanceController> logger, IDistanceCalculationService distanceCalculationService)
        {
            _logger = logger;
            _distanceCalculationService = distanceCalculationService;
        }

        [HttpPost]
        public async Task<ActionResult<Response<DistanceResponseVM>>> Post([FromBody] DistanceRequestVM distanceRequest)
        {
            var result = await _distanceCalculationService.GetDistanceAsync(distanceRequest);

            if (result.ResponseStatus == Domain.Enums.Status.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}