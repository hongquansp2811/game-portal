using GamePortal.Core.Entities;

namespace GamePortal.Core.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetActiveCategoriesAsync();
    Task<Category?> GetBySlugAsync(string slug);
}

