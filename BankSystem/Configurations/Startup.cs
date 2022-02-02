
using Banck.Api.Configurations;
using Bank.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BankSystem.Configurations
{
    public class Startup
    {
        private readonly string _policyName = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank.Api", Version = "v1" });
            });

            // var server = Configuration["DatabaseServer"] ?? "";
            // var port = Configuration["DatabasePort"] ?? "";
            // var user = Configuration["DatabaseUser"] ?? "";
            // var password = Configuration["DatabasePassword"] ?? "";
            // var database = Configuration["DatabaseName"] ?? "";

            // var connectionString = $"Server={server}, {port}; Initial Catalog={database}; User ID={user}; Password={password}"; //Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BankContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                , ServiceLifetime.Transient
            );

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDependencyInjection();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            DataBaseManagementService.MigrationInitialisation(app);
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseRouting();
            app.UseCors(_policyName);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
