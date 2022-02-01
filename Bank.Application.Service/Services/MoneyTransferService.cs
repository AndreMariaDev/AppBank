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
    public class MoneyTransferService : IMoneyTransferService
    {
        private readonly IMoneyTransferRepository _moneyTransferRepository;   
        #region Constructor
        public MoneyTransferService(IMoneyTransferRepository moneyTransferRepository) 
        {
            _moneyTransferRepository = moneyTransferRepository;
        }
        #endregion


        public async Task<Guid> AddMoneyTransfer(MoneyTransfer item)
        {
            return await _moneyTransferRepository.AddMoneyTransfer(item);
        }

        public void UpdateStatus(MoneyTransfer item)
        {
            _moneyTransferRepository.UpdateStatus(item);
        }

        public void CancelMoneyTransfer(MoneyTransfer item)
        {
            item.IsActive = false;
            item.Status = "C";
            _moneyTransferRepository.CancelMoneyTransfer(item);
        }

        public async Task<IEnumerable<MoneyTransfer>> GetAllMoneyTransfer(int _offset = 1, int _limit = 10)
        {

            return await _moneyTransferRepository.GetAllMoneyTransfer(_offset, _limit);
        }

        public async Task<MoneyTransfer> GetMoneyTransferByCode(Guid code)
        {

            return await _moneyTransferRepository.GetMoneyTransferByCode(code);
        }

        public async Task<MoneyTransfer> GetMoneyTransferByFilter(Expression<Func<MoneyTransfer, bool>> predicate)
        {

            return await _moneyTransferRepository.GetMoneyTransferByFilter(predicate);
        }

    }
}
