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

namespace Bank.Infra.Repository
{ 
    public class UserCredentialsRepository : Repository<UserCredentials>, IUserCredentialsRepository
    {
        #region Constructor
        public UserCredentialsRepository(BankContext context) : base(context)
        {
 
        }
        #endregion


        public async Task<Guid> AddCredential(UserCredentials item) 
        {
            return await AddItemAsync(item);
        }

        public async Task<Boolean> ValidationUserCredential(String Login, String Password)
        {
            return await this._context.Set<UserCredentials>().AsNoTracking()
                .AnyAsync(x => x.Login == Login && x.Password == Password);
        }

        public void UpdateCredential(UserCredentials item)
        {
            this.Update(item);
        }

        public void DeleteCredential(UserCredentials item)
        {
            item.IsActive = false;
            this.Update(item);
        }

    } 
} 
