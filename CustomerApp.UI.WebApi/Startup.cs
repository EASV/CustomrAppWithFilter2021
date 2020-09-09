using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.DomainService;
using CustomerApp.Infrastructure.DBInitialization;
using CustomerApp.Infrastructure.MSSQL.Data;
using CustomerApp.Infrastructure.MSSQL.Data.Repositories;
using CustomerApp.Infrastructure.Static.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json;

namespace CustomerApp.UI.WebApi
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            
            services.AddDbContext<CustomerAppContext>(
                opt =>
                {
                    opt.UseSqlite("Data Source=customerApp.db")
                        .EnableSensitiveDataLogging(); 

                });
            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddControllers().AddNewtonsoftJson(o => 
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // o.SerializerSettings.MaxDepth = 1;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<CustomerAppContext>();
                    // ctx.Database.EnsureDeleted();
                    // ctx.Database.EnsureCreated();
                    var repo = scope.ServiceProvider.GetService<ICustomerRepository>();
                    new DBInitializer(repo).InitData();
                }
            }

            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // localhost/pets
            // localhost/customers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
