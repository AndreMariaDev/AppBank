using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Models
{
    public class User : DomainEntity
    {
        [Required]
        public string FistName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Document { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public enumTypeUser TypeUser { get; set; }
        public Guid CredentialsCode { get; set; }
        public UserCredentials Credentials { get; set; }
    }
    public enum enumTypeUser
    {
        Undefined = 0,
        Accountant = 1,
        Admin = 2,
        Manager = 3,
        Operational = 4
    }
}
