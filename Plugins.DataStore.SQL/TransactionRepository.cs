using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext _marketContext;

        public TransactionRepository(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public IEnumerable<Transaction> GetAllTransactions(string cashierName)
        {
            if (string.IsNullOrEmpty(cashierName))
                return _marketContext.Transactions.ToList();
            else
                return _marketContext.Transactions.Where(t => EF.Functions.Like(t.CashierName, $"%{cashierName}%"));
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (!string.IsNullOrEmpty(cashierName))
                return _marketContext.Transactions.Where(t => EF.Functions.Like(t.CashierName, $"%{cashierName}%") && t.TimeStamp.Date == date.Date).ToList();
            else
                return _marketContext.Transactions.Where(t => t.TimeStamp.Date == date.Date).ToList();
        }

        public void Save(string cashierName, int productId, double price, int beforeQty, int qty)
        {
            var transaction = new Transaction()
            {
                CashierName = cashierName,
                ProductId = productId,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = qty,
                TimeStamp = DateTime.Now.ToLocalTime(),
            };
            _marketContext.Transactions.Add(transaction);
            _marketContext.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (!string.IsNullOrEmpty(cashierName))
                return _marketContext.Transactions.Where(t => EF.Functions.Like(t.CashierName, $"%{cashierName}%")
                && t.TimeStamp.Date >= startDate.Date && t.TimeStamp.Date <= endDate.Date).ToList();
            else
                return _marketContext.Transactions.Where(t => t.TimeStamp.Date >= startDate.Date && t.TimeStamp.Date <= endDate.Date).ToList();
        }
    }
}
