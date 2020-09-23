using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.DomainService;
using CustomerApp.Infrastructure.DBInitialization;
using CustomerApp.Infrastructure.SQLite.Data;
using CustomerApp.Infrastructure.SQLite.Data.Repositories;
using CustomerApp.Infrastructure.Static.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CustomerRepository = CustomerApp.Infrastructure.SQLite.Data.Repositories.CustomerRepository;

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
        {   var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddConsole();
                }
            );
            services.AddDbContext<CustomerAppLiteContext>(
                opt =>
                {
                    opt.UseLoggerFactory(loggerFactory)
                        .AddInterceptors(new DBInterceptor())
                        .UseSqlite("Data Source=customerApp.db"); 

                });
            
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();
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
                    var ctx = scope.ServiceProvider.GetService<CustomerAppLiteContext>(); 
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    var custRepository = scope.ServiceProvider.GetService<ICustomerRepository>();
                    var addressRepository = scope.ServiceProvider.GetService<IAddressRepository>();
                    var cityRepository = scope.ServiceProvider.GetService<ICityRepository>();
                    new DBInitializer(cityRepository, custRepository, addressRepository).InitData();
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
