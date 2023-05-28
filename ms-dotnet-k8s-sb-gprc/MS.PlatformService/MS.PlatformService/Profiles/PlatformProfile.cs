using AutoMapper;
using MS.PlatformService.Dtos;
using MS.PlatformService.Models;

namespace MS.PlatformService.Profiles
{
    public class PlatformProfile:Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}
