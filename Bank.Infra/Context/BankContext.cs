using Bank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//using Serilog;

namespace Bank.Infra.Context
{
    public class BankContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public BankContext(DbContextOptions<BankContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        #region BanckAttendance
        public DbSet<UserCredentials> UsersCredentials { get; set; }
        public DbSet<BankClient> BankClients { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //#region Attendance

            //builder.Entity<UserCredentials>()
            //    .HasOne<User>(u => u.User)
            //    .WithMany(c => c.UserCredentialsItens)
            //    .HasForeignKey(f => f.UserCode);

            //builder.Entity<Assets>()
            //    .HasOne<User>(u => u.User)
            //    .WithMany(c => c.ListAssets)
            //    .HasForeignKey(f => f.UserCode);

            //builder.Entity<User>()
            //    .HasOne(u => u.BankAccount)
            //    .WithOne(c => c.User)
            //    .HasForeignKey<BankAccount>(u => u.UserCode);

            //builder.Entity<BankAccountHistory>()
            //    .HasOne<BankAccount>(u => u.BankAccount)
            //    .WithMany(c => c.ListBankAccountHistories)
            //    .HasForeignKey(f => f.BankAccountCode);

            //#endregion
        }
    }
}
