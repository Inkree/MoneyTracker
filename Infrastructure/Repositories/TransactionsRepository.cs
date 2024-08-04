
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
           return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction?>> GetByUserIdAsync(string userId)
        {
            return await _dbSet.Where(x => x.UserId == userId).ToListAsync();
        }

        public Task UpdateAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

       
    }
}
