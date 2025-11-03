using AutoMapper;
using GamePortal.Core.DTOs;
using GamePortal.Core.Interfaces;
using GamePortal.Core.Services;

namespace GamePortal.Infrastructure.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GameService(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GameDTO>> GetFeaturedGamesAsync(int count = 10)
    {
        var games = await _gameRepository.GetFeaturedGamesAsync(count);
        return _mapper.Map<IEnumerable<GameDTO>>(games);
    }

    public async Task<IEnumerable<GameDTO>> GetHotGamesAsync(int count = 10)
    {
        var games = await _gameRepository.GetHotGamesAsync(count);
        return _mapper.Map<IEnumerable<GameDTO>>(games);
    }

    public async Task<IEnumerable<GameDTO>> GetLatestGamesAsync(int count = 20)
    {
        var games = await _gameRepository.GetLatestGamesAsync(count);
        return _mapper.Map<IEnumerable<GameDTO>>(games);
    }

    public async Task<IEnumerable<GameDTO>> GetGamesByCategoryAsync(int categoryId, int skip = 0, int take = 10)
    {
        var games = await _gameRepository.GetGamesByCategoryAsync(categoryId, skip, take);
        return _mapper.Map<IEnumerable<GameDTO>>(games);
    }

    public async Task<GameDetailDTO?> GetGameBySlugAsync(string slug)
    {
        var game = await _gameRepository.FirstOrDefaultAsync(g => g.Slug == slug);
        if (game == null) return null;

        var dto = _mapper.Map<GameDetailDTO>(game);
        if (game.Galleries.Any())
        {
            dto.GalleryImages = game.Galleries.OrderBy(g => g.DisplayOrder).Select(g => g.ImageUrl).ToList();
        }

        return dto;
    }

    public async Task<IEnumerable<GameDTO>> SearchGamesAsync(string searchTerm)
    {
        var games = await _gameRepository.SearchGamesAsync(searchTerm);
        return _mapper.Map<IEnumerable<GameDTO>>(games);
    }
}

