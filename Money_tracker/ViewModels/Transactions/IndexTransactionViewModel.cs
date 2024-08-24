

using Core.models;

namespace Money_tracker.ViewModels.Transactions
{
    public class IndexTransactionViewModel
    {
        public decimal Balance { get; set; }
        public List<IGrouping<DateTime, Transaction?>>? Transactions { get; set; }
    }
}
