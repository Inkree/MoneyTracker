
using Core.interfaces;
using Core.models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly MoneyTrackerDbContext _dbContext;
        private readonly DbSet<Transaction> _dbSet;
        public TransactionsRepository(MoneyTrackerDbContext dbContext) {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Transaction>();
        }

        public async Task AddAsync(Transaction transaction)
        {
           await _dbSet.AddAsync(transaction);
           await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var transaction = await GetByIdAsync(Id);
            if(transaction != null)
            {
                _dbSet.Remove(transaction);
                await _dbContext.SaveChangesAsync();
            }
        }

        public  async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<IEnumerable<Transaction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Transaction?> GetByIdAsync(string id)
        {
            return await _dbSet
        .Include(t => t.Category)  
        .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Transaction?>> GetByUserIdAsync(string userId)
        {
            return await _dbSet.Where(x => x.UserId == userId).Include(x => x.Category).ToListAsync();
        }

        public Task UpdateAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryExpense>> GetTotalSpentByAllCategoriesAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet.Where(t => t.CreatedAt >= startDate && t.CreatedAt <= endDate && t.Amount < 0)
                .GroupBy(t => t.Category)
                .Select(g => new CategoryExpense
                {
                    CategoryId = g.Key.Id,
                    CategoryName = g.Key.Name,
                    SvgContent = g.Key.SvgContent,
                    Color = g.Key.Color,
                    TotalSpent = g.Sum(t => t.Amount)
                })
                .ToListAsync();
        }


        public IEnumerable<Transaction> Find(string name)
        {
            decimal nameDecimal;
            bool isNumber = Decimal.TryParse(name, out nameDecimal);
            return _dbSet.Where(t => t.Note.Contains(name) ||
                          (isNumber && Math.Round(t.Amount, 0) == nameDecimal) ||
                          t.Category.Name.Contains(name)   
                          ).Include(t => t.Category);
        }

    }
}
