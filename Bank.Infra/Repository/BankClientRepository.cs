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
    public class BankClientRepository : Repository<BankClient>, IBankClientRepository
    {
        #region Constructor
        public BankClientRepository(BankContext context) : base(context)
        {

        }
        #endregion

        public async Task<Guid> AddClient(BankClient item)
        {
            return await AddItemAsync(item);
        }

        public void UpdateClient(BankClient item)
        {
            this.Update(item);
        }

        public void DeleteClient(BankClient item)
        {
            item.IsActive = false;
            this.Update(item);
        }

        public async Task<IEnumerable<BankClient>> GetAllClients(int _offset = 1, int _limit = 10) 
        {
            
            return await GetAllAsync(_offset, _limit);
        }

        public async Task<BankClient> GetClientsByCode(Guid code)
        {

            return await GetIdAsync(code);
        }

        public async Task<BankClient> GetClientsByFilter(Expression<Func<BankClient, bool>> predicate)
        {

            return await GetAsync(predicate);
        }

    }
}
