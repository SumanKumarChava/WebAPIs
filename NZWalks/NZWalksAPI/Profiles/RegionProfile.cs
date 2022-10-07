using AutoMapper;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDTO>()
                .ForMember(t => t.RegionId, options => options.MapFrom(src => src.Id))
                .ForMember(t => t.RegionName, options => options.MapFrom(src => src.Name))
                .ForMember(t => t.TotalPopulation, options => options.MapFrom(src => src.Population))
                .ForMember(t => t.RegionCode, options => options.MapFrom(src => src.Code));

        }
    }
}
