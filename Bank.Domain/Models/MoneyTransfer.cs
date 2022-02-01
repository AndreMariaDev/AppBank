using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Models
{
    public class MoneyTransfer : DomainEntity
    {
        public string Event { get; set; }
        public string TargetBank { get; set; }
        public string TargetBranch { get; set; }
        public string TargetAccount { get; set; }

        public string OriginBank { get; set; }
        public string OriginBranch { get; set; }
        public string OriginAccount { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
    
}
