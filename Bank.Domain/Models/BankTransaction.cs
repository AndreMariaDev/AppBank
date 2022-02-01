using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Models
{
    public class BankTransaction : DomainEntity
    {
        public string Event { get; set; }
        public decimal Amount { get; set; }

        public Guid AccountCode { get; set; }
        public BankAccount BankAccount { get; set; }
        public string Status { get; set; }
    }
}
