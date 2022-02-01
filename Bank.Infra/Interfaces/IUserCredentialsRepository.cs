using Bank.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Infra.Interfaces
{ 
    public interface IUserCredentialsRepository : IRepository<UserCredentials>
    {
        Task<Guid> AddCredential(UserCredentials item);
        Task<Boolean> ValidationUserCredential(String Login, String Password);
        void UpdateCredential(UserCredentials item);
        void DeleteCredential(UserCredentials item);
    } 
} 
