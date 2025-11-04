using AutoMapper;
using GamePortal.Core.DTOs;
using GamePortal.Core.Entities;
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

    // Read operations
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

    public async Task<GameDTO?> GetGameByIdAsync(int id)
    {
        var game = await _gameRepository.GetByIdAsync(id);
        return game == null ? null : _mapper.Map<GameDTO>(game);
    }

    public async Task<IEnumerable<GameDTO>> GetAllGamesAsync(int skip = 0, int take = 50)
    {
        var games = await _gameRepository.GetAllGamesAsync(skip, take);
        return _mapper.Map<IEnumerable<GameDTO>>(games);
    }

    // CRUD operations
    public async Task<GameDTO> CreateGameAsync(CreateGameDTO dto)
    {
        var game = _mapper.Map<Game>(dto);
        game.CreatedAt = DateTime.UtcNow;
        await _gameRepository.AddAsync(game);
        var createdGame = await _gameRepository.GetByIdAsync(game.Id);
        return _mapper.Map<GameDTO>(createdGame!);
    }

    public async Task<GameDTO> UpdateGameAsync(int id, UpdateGameDTO dto)
    {
        var game = await _gameRepository.GetByIdAsync(id);
        if (game == null)
            throw new ArgumentException($"Game with id {id} not found");

        _mapper.Map(dto, game);
        game.UpdatedAt = DateTime.UtcNow;
        _gameRepository.Update(game);
        
        var updatedGame = await _gameRepository.GetByIdAsync(id);
        return _mapper.Map<GameDTO>(updatedGame!);
    }

    public async Task<bool> DeleteGameAsync(int id)
    {
        var game = await _gameRepository.GetByIdAsync(id);
        if (game == null) return false;

        await _gameRepository.DeleteAsync(id);
        return true;
    }

    public async Task IncrementPlayCountAsync(int gameId)
    {
        var game = await _gameRepository.GetByIdAsync(gameId);
        if (game != null)
        {
            game.PlayCount++;
            _gameRepository.Update(game);
        }
    }
}

