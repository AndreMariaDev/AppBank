using Bank.Domain.Models;
using Bank.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bank.Infra.Repository;

namespace Bank.Infra.Service
{
    public class BankTransactionService : IBankTransactionService
    {
        private IBankTransactionRepository _bankTransactionRepository;

        #region Constructor
        public BankTransactionService(IBankTransactionRepository bankTransactionRepository)
        {
            _bankTransactionRepository = bankTransactionRepository;
        }
        #endregion


        public async Task<Guid> AddBankTransaction(BankTransaction item)
        {
            return await _bankTransactionRepository.AddBankTransaction(item);
        }

        public void UpdateStatus(BankTransaction item)
        {
            _bankTransactionRepository.UpdateStatus(item);
        }

        public void CancelBankTransaction(BankTransaction item)
        {
            item.IsActive = false;
            item.Status = "C";
            _bankTransactionRepository.CancelBankTransaction(item);
        }

        public async Task<IEnumerable<BankTransaction>> GetAllBankTransaction(int _offset = 1, int _limit = 10)
        {

            return await _bankTransactionRepository.GetAllBankTransaction(_offset, _limit);
        }

        public async Task<BankTransaction> GetBankTransactionByCode(Guid code)
        {

            return await _bankTransactionRepository.GetBankTransactionByCode(code);
        }

        public async Task<BankTransaction> GetBankTransactionByFilter(Expression<Func<BankTransaction, bool>> predicate)
        {

            return await _bankTransactionRepository.GetBankTransactionByFilter(predicate);
        }

    }
}
