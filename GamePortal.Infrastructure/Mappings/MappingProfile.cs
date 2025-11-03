using AutoMapper;
using GamePortal.Core.DTOs;
using GamePortal.Core.Entities;

namespace GamePortal.Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Game, GameDTO>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.CategorySlug, opt => opt.MapFrom(src => src.Category.Slug));

        CreateMap<Game, GameDetailDTO>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.CategorySlug, opt => opt.MapFrom(src => src.Category.Slug));

        CreateMap<Category, CategoryDTO>();
    }
}

