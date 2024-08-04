using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Transaction
{
    public class TransactionDto
    {
        public TransactionDto(Guid id,string note,DateOnly dateCreated,decimal ammount,Category category) { }
        public Guid Id { get; set; }
        public string Note { get; set; }
        public DateOnly DateCreated { get; set; }
        public decimal Ammount { get; set; }
        public Category Category { get; set; }
    }
}
