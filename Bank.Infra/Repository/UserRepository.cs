using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

using Bank.Infra.Repository;
using Bank.Domain.Models;
using Bank.Infra.Context;
using Bank.Infra.Interfaces;
using System.Linq.Expressions;

namespace Bank.Infra.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructor
        public UserRepository(BankContext context) : base(context)
        {

        }
        #endregion


        public async Task<Guid> AddUser(User item)
        {
            return await AddItemAsync(item);
        }

        public async Task<Boolean> ValidationUser(string Document)
        {
            return await this._context.Set<UserCredentials>().AsNoTracking()
                .AnyAsync(x => x.Document == Document);
        }

        public void UpdateUser(User item)
        {
            this.Update(item);
        }

        public void DeleteUser(User item)
        {
            item.IsActive = false;
            this.Update(item);
        }

        public async Task<IEnumerable<User>> GetAllUser(int _offset = 1, int _limit = 10)
        {

            return await GetAllAsync(_offset, _limit);
        }

        public async Task<User> GetUserByCode(Guid code)
        {

            return await GetIdAsync(code);
        }

        public async Task<User> GetClientsByFilter(Expression<Func<User, bool>> predicate)
        {

            return await GetAsync(predicate);
        }
    }
}
