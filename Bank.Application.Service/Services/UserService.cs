using Bank.Application.Service.Interfaces;
using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bank.Infra.Repository;
using Bank.Infra.Interfaces;

namespace Bank.Application.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> AddUser(User item)
        {
            return await _userRepository.AddUser(item);
        }

        public void DeleteUser(User item)
        {
            _userRepository.DeleteUser(item);
        }

        public async Task<IEnumerable<User>> GetAllUser(int _offset = 1, int _limit = 10)
        {
            return await _userRepository.GetAllUser(_offset ,_limit);
        }

        public async Task<User> GetClientsByFilter(Expression<Func<User, bool>> predicate)
        {
            return await _userRepository.GetClientsByFilter(predicate);
        }

        public async Task<User> GetUserByCode(Guid code)
        {
            return await _userRepository.GetUserByCode(code);
        }

        public void UpdateUser(User item)
        {
            _userRepository.UpdateUser(item); ;
        }

        public async Task<bool> ValidationUser(string Document)
        {
            return await _userRepository.ValidationUser(Document);
        }
    }
}
