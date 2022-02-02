using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infra.Interfaces
{
    public interface IRepository<T> where T : DomainEntity
    {
        Task<Guid> AddItemAsync(T objModel);
        void AddRange(IEnumerable<T> objModel);
        T GetId(Guid id);
        Task<T> GetIdAsync(Guid id);
        T Get(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(int _offset = 1, int _limit = 10);
        int Count();
        Task<int> CountAsync();
        void Update(T objModel);
        void Remove(T objModel);
        void Dispose();
    }
}
