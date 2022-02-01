using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Models
{
    public class BankClient : DomainEntity
    {
        [Required]
        public string FistName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public String Document { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String PhoneNumber { get; set; }

        public Guid CredentialsCode { get; set; }
        public UserCredentials Credentials { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }

    }
}
