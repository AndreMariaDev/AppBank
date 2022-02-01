
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Bank.Domain.Models;
using Bank.Infra.Context;
using System.Linq.Expressions;
using Bank.Infra.Interfaces;

namespace Bank.Infra.Repository
{ 
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        #region Constructor
        public BankAccountRepository(BankContext context) : base(context)
        {
 
        }
        #endregion
        public async Task<Boolean> ValidationBankAccount(String accountNumber,String branch)
        {
            return await this._context.Set<BankAccount>().AsNoTracking()
                .AnyAsync(x => x.AccountNumber == accountNumber && x.Branch == branch);
        }

        public async Task<Guid> AddAccount(BankAccount item)
        {
            return await AddItemAsync(item);
        }

        public void UpdateAccount(BankAccount item)
        {
            this.Update(item);
        }

        public void DeleteAccount(BankAccount item)
        {
            item.IsActive = false;
            this.Update(item);
        }

        public async Task<IEnumerable<BankAccount>> GetAllAccounts(int _offset = 1, int _limit = 10)
        {

            return await GetAllAsync(_offset, _limit);
        }

        public async Task<BankAccount> GetAccountsByCode(Guid code)
        {

            return await GetIdAsync(code);
        }

        public async Task<BankAccount> GetAccountsByFilter(Expression<Func<BankAccount, bool>> predicate)
        {

            return await GetAsync(predicate);
        }
    } 
} 
