using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoriesRepository
    {
        public Task AddAsync(Category category);
        public Task DeleteAsync(string id);
        public void UpdateAsync(Category category);
        public Task<Category?> GetByIdAsync(string id);
        public Task<IEnumerable<Category>> GetAllByUserIdAsync(string userId);
        public Task<IEnumerable<Category>> GetAllByNameAsync(string name);

    }
}
