
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Data;
using Bank.Domain.Models;
using System.Linq.Expressions;
using Bank.Infra.Interfaces;
using Bank.Infra.Repository;

namespace Bank.Infra.Service
{ 
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        #region Constructor
        public BankAccountService(IBankAccountRepository bankAccountRepository) 
        {
            _bankAccountRepository = bankAccountRepository;
        }
        #endregion
        public async Task<Boolean> ValidationBankAccount(String accountNumber,String branch)
        {
            return await _bankAccountRepository.ValidationBankAccount(accountNumber, branch);
        }

        public async Task<Guid> AddAccount(BankAccount item)
        {
            return await _bankAccountRepository.AddAccount(item);
        }

        public void UpdateAccount(BankAccount item)
        {
            _bankAccountRepository.UpdateAccount(item);
        }

        public void DeleteAccount(BankAccount item)
        {
            _bankAccountRepository.DeleteAccount(item);
        }

        public async Task<IEnumerable<BankAccount>> GetAllAccounts(int _offset = 1, int _limit = 10)
        {

            return await _bankAccountRepository.GetAllAccounts(_offset, _limit);
        }

        public async Task<BankAccount> GetAccountsByCode(Guid code)
        {

            return await _bankAccountRepository.GetAccountsByCode(code);
        }

        public async Task<BankAccount> GetAccountsByFilter(Expression<Func<BankAccount, bool>> predicate)
        {

            return await _bankAccountRepository.GetAccountsByFilter(predicate);
        }
    } 
} 
