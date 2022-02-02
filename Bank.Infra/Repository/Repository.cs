using Bank.Domain.Models;
using Bank.Infra.Context;
using Bank.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : DomainEntity
    {
        protected readonly BankContext _context;
        protected readonly DbSet<T> DbSet;

        public Repository(BankContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        #region Methods

        public async Task<Guid> AddItemAsync(T objModel)
        {
            _context.Set<T>().Add(objModel);
            await _context.SaveChangesAsync();
            return objModel.Code;
        }

        public void AddRange(IEnumerable<T> objModel)
        {
            _context.Set<T>().AddRange(objModel);
            _context.SaveChanges();
        }

        public T GetId(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where<T>(predicate).ToList();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() =>
                _context.Set<T>().Where<T>(predicate));
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<T>());
        }

        public async Task<IEnumerable<T>> GetAllAsync(int _offset = 1, int _limit = 10)
        {
            var skip = (_offset - 1) * _limit;
            return await Task.Run(() => _context.Set<T>().Skip(skip).Take(_limit));
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public void Update(T objModel)
        {
            _context.Entry(objModel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(T objModel)
        {
            _context.Set<T>().Remove(objModel);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion

    }
}
