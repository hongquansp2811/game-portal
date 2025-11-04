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
        
        // CRUD mappings
        CreateMap<CreateGameDTO, Game>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.PlayCount, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Galleries, opt => opt.Ignore())
            .ForMember(dest => dest.Reviews, opt => opt.Ignore());

        CreateMap<UpdateGameDTO, Game>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.PlayCount, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Galleries, opt => opt.Ignore())
            .ForMember(dest => dest.Reviews, opt => opt.Ignore());
    }
}

