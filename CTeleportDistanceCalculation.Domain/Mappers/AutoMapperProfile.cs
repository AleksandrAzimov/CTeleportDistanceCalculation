using AutoMapper;
using CTeleportDistanceCalculation.Data.Models;
using CTeleportDistanceCalculation.Domain.Models;

namespace CTeleportDistanceCalculation.Domain.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Airport, Coordinates>()
                .ConvertUsing(x => new Coordinates(x.Location.Lat, x.Location.Lon));
        }
    }
}