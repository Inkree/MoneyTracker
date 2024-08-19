using Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class Transaction : BaseEntity,IAuditableEntity
    {
        public Transaction() {
            Note = string.Empty;
            CategoryId = string.Empty;
            UserId = string.Empty;
       
        }
        public Transaction(string note, decimal ammount,string userId,string categoryId)
        {
            Amount = ammount;
            Note = note;
            UserId = userId;
            CategoryId = categoryId;
        }
        
        public string Note { get; set; }
        public DateOnly? DateCreated { get; set; }
        public decimal Amount { get; set; }
        public string CategoryId { get; set; }
        public Category? Category { get; set; }
        public string UserId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string? lastModifiedBy { get; set; }
        public DateTimeOffset? lastModifiedAt { get; set; }
    }
}
