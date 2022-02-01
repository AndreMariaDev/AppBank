using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infra.Interfaces
{
    public interface IBankTransactionService
    {
        Task<Guid> AddBankTransaction(BankTransaction item);
        void UpdateStatus(BankTransaction item);
        void CancelBankTransaction(BankTransaction item);
        Task<IEnumerable<BankTransaction>> GetAllBankTransaction(int _offset = 1, int _limit = 10);
        Task<BankTransaction> GetBankTransactionByCode(Guid code);
        Task<BankTransaction> GetBankTransactionByFilter(Expression<Func<BankTransaction, bool>> predicate);
    }
}
