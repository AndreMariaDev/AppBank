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
    public class BankTransactionRepository : Repository<BankTransaction>, IBankTransactionRepository
    {
        #region Constructor
        public BankTransactionRepository(BankContext context) : base(context)
        {

        }
        #endregion


        public async Task<Guid> AddBankTransaction(BankTransaction item)
        {
            return await AddItemAsync(item);
        }

        public void UpdateStatus(BankTransaction item)
        {
            this.Update(item);
        }

        public void CancelBankTransaction(BankTransaction item)
        {
            item.IsActive = false;
            item.Status = "C";
            this.Update(item);
        }

        public async Task<IEnumerable<BankTransaction>> GetAllBankTransaction(int _offset = 1, int _limit = 10)
        {

            return await GetAllAsync(_offset, _limit);
        }

        public async Task<BankTransaction> GetBankTransactionByCode(Guid code)
        {

            return await GetIdAsync(code);
        }

        public async Task<BankTransaction> GetBankTransactionByFilter(Expression<Func<BankTransaction, bool>> predicate)
        {

            return await GetAsync(predicate);
        }

    }
}
