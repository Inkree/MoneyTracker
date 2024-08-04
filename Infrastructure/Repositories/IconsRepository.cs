using Core.interfaces;
using Core.models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IconsRepository : IIconsRepository
    {
        private readonly MoneyTrackerDbContext _dbContext;
        private readonly DbSet<Icon> _dbSet;
        public IconsRepository(MoneyTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Icon>();
        }
        public async Task AddAsync(Icon icon)
        {
            await _dbSet.AddAsync(icon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var transaction = await GetByIdAsync(Id);
            if (transaction != null)
            {
                _dbSet.Remove(transaction);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Icon?> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<IEnumerable<Icon>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
