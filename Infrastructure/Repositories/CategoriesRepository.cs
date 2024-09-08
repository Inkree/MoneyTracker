using Application.Interfaces;
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
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly MoneyTrackerDbContext _dbContext;
        private readonly DbSet<Category> _dbSet;
        public CategoriesRepository(MoneyTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Category>();
        }
        public async Task AddAsync(Category category)
        {
            try
            {
               
                await _dbSet.AddAsync(category);         
                await _dbContext.SaveChangesAsync();          
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
        }


      

        public async Task DeleteAsync(string id)
        {
            var category = await GetByIdAsync(id);
            if(category != null)
            {
                _dbSet.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllByUserIdAsync(string userId)
        {
            return await _dbSet.Where(x => x.UserId == userId || x.UserId == null).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllByNameAsync(string name)
        {
            return await _dbSet.Where(x => x.Name == name).ToListAsync();
        }

        public Task<IEnumerable<Category>> GetAllByNameAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Category?> GetByIdAsync(string id)
        {
           return await _dbSet.Where(x=>x.Id == id).FirstOrDefaultAsync();   
        }

        public async Task UpdateAsync(Category category)
        {
            _dbSet.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Category> Find(string name)
        {
            return _dbSet.Where(c => c.Name.Contains(name));      
        }

       


    }   
}
