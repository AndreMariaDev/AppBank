using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Models
{
    public class UserCredentials: DomainEntity
    {
        [Required]
        public String Login { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Document { get; set; }
    }
}
