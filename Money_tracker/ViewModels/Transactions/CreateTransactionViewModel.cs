using Core.models;

namespace Money_tracker.ViewModels.Transactions
{
    public class CreateTransactionViewModel
    {
        public CreateTransactionViewModel()
        {
            Categories = new List<Category>();
            Transaction = new Transaction();
        }
        public IEnumerable<Category?> Categories { get; set; }
        public Transaction Transaction { get; set; }
    }
}
