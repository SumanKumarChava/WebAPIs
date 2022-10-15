using AutoMapper;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Walk, WalkDTO>().ReverseMap();

            CreateMap<WalkDifficulty, WalkDifficultyDTO>().ReverseMap();
        }
    }
}
