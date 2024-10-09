using Application.DTOs.Transaction;
using Application.Interfaces;
using Core.interfaces;
using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        public TransactionsService(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }
        public async Task Create(Transaction transaction)
        {
            await _transactionsRepository.AddAsync(transaction);
        }

        public async Task<Transaction?> GetByIdAsync(string id)
        {
            return await _transactionsRepository.GetByIdAsync(id);
        }

        public async Task Delete(string id)
        {
            await _transactionsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Transaction?>> GetAllByUserId(string userId)
        {
            return await _transactionsRepository.GetByUserIdAsync(userId);

        }

        public async Task<List<IGrouping<DateTime, Transaction?>>> GetGroupedTransactionsByUserId(string userId)
        {
            var today = DateTime.Today;
            var transactions = await _transactionsRepository.GetByUserIdAsync(userId);
            var groupedTransactions = transactions.GroupBy(t => t.CreatedAt.Value.Date)
                  .OrderByDescending(g => g.Key)
                  .ToList();
            return groupedTransactions;
        }

        public async Task<decimal> GetUserBalance(string userId)
        {
            var transactions = await _transactionsRepository.GetByUserIdAsync(userId);
            return transactions.Sum(t => t.Amount);

        }

        public async Task<List<CategoryExpense>> GetTotalSpentByAllCategoriesAsync(DateTime startDate, DateTime endDate)
        {
            return await _transactionsRepository.GetTotalSpentByAllCategoriesAsync(startDate, endDate);
        }

        public IEnumerable<Transaction> Find(string name)
        {
           return _transactionsRepository.Find(name);
        }


    }
}
