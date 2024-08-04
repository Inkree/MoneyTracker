using Core.models;

namespace Application.Interfaces
{
    public interface ICategoriesService
    {
        Task Create(Category category);
        Task Delete(string id);
        Category Edit(string id, Category transaction);
        Task<IEnumerable<Category?>> GetAllByUserIdAsync(string userId);
    }
}
