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

      
        public async Task Delete(string id)
        {
           await _transactionsRepository.DeleteAsync(id);
        }

        public Transaction Edit(string id, Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaction?>> GetAllByUserId(string userId)
        {
            return await  _transactionsRepository.GetByUserIdAsync(userId);
          
        }

        bool ITransactionsService.Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
