using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Data;


using Bank.Infra.Service;
using Bank.Domain.Models;
using Bank.Infra.Interfaces;
using Bank.Infra.Repository;

namespace Bank.Infra.Service
{ 
    public class UserCredentialsService : IUserCredentialsService
    {
        private readonly IUserCredentialsRepository _userCredentialsRepository;
        #region Constructor
        public UserCredentialsService(IUserCredentialsRepository userCredentialsRepository) 
        {
            _userCredentialsRepository = userCredentialsRepository;
        }
        #endregion


        public async Task<Guid> AddCredential(UserCredentials item) 
        {
            return await _userCredentialsRepository.AddCredential(item);
        }

        public async Task<Boolean> ValidationUserCredential(String Login, String Password)
        {
            return await _userCredentialsRepository.ValidationUserCredential(Login,Password);
        }

        public void UpdateCredential(UserCredentials item)
        {
            _userCredentialsRepository.UpdateCredential(item);
        }

        public void DeleteCredential(UserCredentials item)
        {
            item.IsActive = false;
            _userCredentialsRepository.DeleteCredential(item);
        }

    } 
} 
