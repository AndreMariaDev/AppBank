using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Models
{
    public class BankAccount : DomainEntity
    {
        [Required]
        public String AccountNumber { get; set; }
        [Required]
        public String Branch { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public bool HasLimit { get; set; }
        public decimal? LimitAmount { get; set; }

        public Guid ClientCode { get; set; }
        public BankClient Client { get; set; }

        public ICollection<BankTransaction> BankTransactions { get; set; }
        public ICollection<MoneyTransfer> MoneyTransfers { get; set; }
    }
}
