using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions(string cashierName);
        IEnumerable<Transaction> GetByDay(string cashierName, DateTime date);
        IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
        void Save(string cashierName, int productId, double price, int beforeQty, int qty);
    }
}
