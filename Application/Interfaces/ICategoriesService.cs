using Core.models;

namespace Application.Interfaces
{
    public interface ICategoriesService
    {
        Task CreateAsync(Category category);
        Task DeleteAsync(string id);
        Category Edit(string id, Category transaction);
        Task<IEnumerable<Category?>> GetAllByUserIdAsync(string userId);
    }
}
