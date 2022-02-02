using Bank.Domain.Models;
using Bank.Infra.Context;
using Bank.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infra.Repository
{
    public class MoneyTransferRepository : Repository<MoneyTransfer>, IMoneyTransferRepository
    {
        #region Constructor
        public MoneyTransferRepository(BankContext context) : base(context)
        {

        }
        #endregion


        public async Task<Guid> AddMoneyTransfer(MoneyTransfer item)
        {
            return await AddItemAsync(item);
        }

        public void UpdateStatus(MoneyTransfer item)
        {
            this.Update(item);
        }

        public void CancelMoneyTransfer(MoneyTransfer item)
        {
            item.IsActive = false;
            item.Status = "C";
            this.Update(item);
        }

        public async Task<IEnumerable<MoneyTransfer>> GetAllMoneyTransfer(int _offset = 1, int _limit = 10)
        {

            return await GetAllAsync(_offset, _limit);
        }

        public async Task<MoneyTransfer> GetMoneyTransferByCode(Guid code)
        {

            return await GetIdAsync(code);
        }

        public async Task<MoneyTransfer> GetMoneyTransferByFilter(Expression<Func<MoneyTransfer, bool>> predicate)
        {

            return await GetAsync(predicate);
        }

    }
}
