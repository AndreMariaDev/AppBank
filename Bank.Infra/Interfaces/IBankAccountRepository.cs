using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bank.Infra.Interfaces
{ 
    public interface IBankAccountRepository : IRepository<BankAccount>
    {
        Task<Boolean> ValidationBankAccount(String accountNumber, String branch);
        Task<Guid> AddAccount(BankAccount item);
        void UpdateAccount(BankAccount item);
        void DeleteAccount(BankAccount item);
        Task<IEnumerable<BankAccount>> GetAllAccounts(int _offset = 1, int _limit = 10);
        Task<BankAccount> GetAccountsByCode(Guid code);
        Task<BankAccount> GetAccountsByFilter(Expression<Func<BankAccount, bool>> predicate);
    } 
} 
