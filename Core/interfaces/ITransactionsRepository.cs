using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.interfaces
{
    public interface ITransactionsRepository
    {

        public Task AddAsync(Transaction transaction);
        public Task DeleteAsync(string Id);
        public Task UpdateAsync(Transaction transaction);
        public Task<Transaction?> GetByIdAsync(string id);
        public Task<IEnumerable<Transaction>> GetAllAsync();
        public Task<IEnumerable<Transaction?>> GetByUserIdAsync(string userId);

    }
}
