using Application.DTOs.Transaction;
using Core.models;


namespace Application.Interfaces
{
    public interface ITransactionsService
    {
        Task Create(Transaction transaction);
        bool Delete(string id);
        Transaction Edit(string id,Transaction transaction);
        Task<IEnumerable<Transaction?>> GetAllByUserId(string userId);
        Task<List<IGrouping<DateTime, Transaction?>>> GetGroupedTransactionsByUserId(string userId);
        public Task<decimal> GetUserBalance(string userId);
    }
}
