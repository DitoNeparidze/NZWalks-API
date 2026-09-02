using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
namespace NZWalks.API.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Region, RegionDto>();
        CreateMap<AddRegionRequestDto, Region>();
        CreateMap<UpdateRegionRequestDto, Region>();
        CreateMap<AddWalkRequestDto, Walk>();
        CreateMap<Walk, WalkDto>();
        CreateMap<UpdateWalkRequestDto, Walk>();
        CreateMap<Difficulty, DifficultyDto>();
        CreateMap<Image, ImageDto>();
    }
}
