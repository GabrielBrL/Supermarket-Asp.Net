using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> _transactions;

        public TransactionInMemoryRepository()
        {
            _transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> GetAllTransactions(string cashierName)
        {
            if (string.IsNullOrEmpty(cashierName))
                return _transactions;
            else
                return _transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));

        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
                return _transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return _transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) && x.TimeStamp.Date == date.Date);
        }

        public void Save(string cashierName, int productId, double price, int beforeQty, int qty)
        {
            int transactionId = 1;
            if (_transactions != null && _transactions.Count > 0)
            {
                transactionId = _transactions.Max(x => x.TransactionId) + 1;
            }
            _transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                Price = price,
                SoldQty = qty,
                BeforeQty = beforeQty,
                CashierName = cashierName,
                TimeStamp = DateTime.UtcNow.ToLocalTime()
            });
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
                return _transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
            else
                return _transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
                x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
        }
    }
}
