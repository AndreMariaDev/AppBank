using Bank.Application.Service.Interfaces;
using Bank.Application.Service.Services;
using Bank.Infra.Interfaces;
using Bank.Infra.Repository;
using Bank.Infra.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.CrossCutting.IoC
{
    public static class NativeInjectionBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<IBankClientRepository, BankClientRepository>();
            services.AddScoped<IBankTransactionRepository, BankTransactionRepository>();
            services.AddScoped<IMoneyTransferRepository, MoneyTransferRepository>();
            services.AddScoped<IUserCredentialsRepository, UserCredentialsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<IBankClientService, BankClientService>();
            services.AddScoped<IBankTransactionService, BankTransactionService>();
            services.AddScoped<IMoneyTransferService, MoneyTransferService>();
            services.AddScoped<IUserCredentialsService, UserCredentialsService>();
            services.AddScoped<IUserService, UserService>();

        }
    }
}
