using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infra.Interfaces
{
    public interface IBankClientRepository : IRepository<BankClient>
    {
        Task<Guid> AddClient(BankClient item);
        void UpdateClient(BankClient item);
        void DeleteClient(BankClient item);
        Task<IEnumerable<BankClient>> GetAllClients(int _offset = 1, int _limit = 10);
        Task<BankClient> GetClientsByCode(Guid code);
        Task<BankClient> GetClientsByFilter(Expression<Func<BankClient, bool>> predicate);
    }
}
