using Bank.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankSystem.Configurations
{
    public static class DataBaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app) 
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<BankContext>().Database.Migrate();
            }
        }
    }
}
