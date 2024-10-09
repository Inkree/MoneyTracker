using Application.DTOs.Transaction;
using Core.models;


namespace Application.Interfaces
{
    public interface ITransactionsService
    {
        public Task Create(Transaction transaction);
        public Task<Transaction?> GetByIdAsync(string id);
        public Task<IEnumerable<Transaction?>> GetAllByUserId(string userId);
        public Task<List<IGrouping<DateTime, Transaction?>>> GetGroupedTransactionsByUserId(string userId);
        public Task<decimal> GetUserBalance(string userId);
        public Task<List<CategoryExpense>> GetTotalSpentByAllCategoriesAsync(DateTime startDate, DateTime endDate);
        public IEnumerable<Transaction> Find(string name);

    }
}
