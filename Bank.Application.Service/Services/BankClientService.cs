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
    public class BankClientService : IBankClientService
    {
        private readonly IBankClientRepository _bankClientRepository;
        #region Constructor
        public BankClientService(IBankClientRepository bankClientRepository)
        {
            _bankClientRepository = bankClientRepository;
        }
        #endregion

        public async Task<Guid> AddClient(BankClient item)
        {
            return await _bankClientRepository.AddClient(item);
        }

        public void UpdateClient(BankClient item)
        {
            _bankClientRepository.UpdateClient(item);
        }

        public void DeleteClient(BankClient item)
        {
            item.IsActive = false;
            _bankClientRepository.DeleteClient(item);
        }

        public async Task<IEnumerable<BankClient>> GetAllClients(int _offset = 1, int _limit = 10) 
        {
            
            return await _bankClientRepository.GetAllClients(_offset, _limit);
        }

        public async Task<BankClient> GetClientsByCode(Guid code)
        {

            return await _bankClientRepository.GetClientsByCode(code);
        }

        public async Task<BankClient> GetClientsByFilter(Expression<Func<BankClient, bool>> predicate)
        {

            return await _bankClientRepository.GetClientsByFilter(predicate);
        }

    }
}
