using Core.models;

namespace Application.Interfaces
{
    public interface ICategoriesService
    {
        Task CreateAsync(Category category);
        Task<IEnumerable<Category?>> GetAllByUserIdAsync(string userId);
        public IEnumerable<Category> Find(string name);
    }
}
