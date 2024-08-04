using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.interfaces
{
    public interface IIconsRepository
    {
        public Task AddAsync(Icon icon);
        public Task DeleteAsync(string Id);
        public Task<Icon> GetByIdAsync(string Id);
        public Task<IEnumerable<Icon>> GetAllAsync();
    }
}
