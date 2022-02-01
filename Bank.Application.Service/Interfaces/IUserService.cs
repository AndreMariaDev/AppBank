using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Service.Interfaces
{
    public interface IUserService
    {
        Task<Guid> AddUser(User item);
        Task<Boolean> ValidationUser(string Document);
        void UpdateUser(User item);
        void DeleteUser(User item);
        Task<IEnumerable<User>> GetAllUser(int _offset = 1, int _limit = 10);
        Task<User> GetUserByCode(Guid code);
        Task<User> GetClientsByFilter(Expression<Func<User, bool>> predicate);
    }
}
