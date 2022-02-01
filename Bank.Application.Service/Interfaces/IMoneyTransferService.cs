using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infra.Interfaces
{
    public interface IMoneyTransferService
    {
        Task<Guid> AddMoneyTransfer(MoneyTransfer item);
        void UpdateStatus(MoneyTransfer item);
        void CancelMoneyTransfer(MoneyTransfer item);
        Task<IEnumerable<MoneyTransfer>> GetAllMoneyTransfer(int _offset = 1, int _limit = 10);
        Task<MoneyTransfer> GetMoneyTransferByCode(Guid code);
        Task<MoneyTransfer> GetMoneyTransferByFilter(Expression<Func<MoneyTransfer, bool>> predicate);
    }
}
