using Application.Customers.Queries.GetCustomersList;
using Application.Interfaces.Persistence;
using Application.Partners.Queries.GetPartnersList;
using Application.Products.Queries.GetProductsList;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Commands.CreateSale.Factory;
using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using Common.Dates;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Customers;
using Persistence.Partners;
using Persistence.Products;
using Persistence.Sales;
using Persistence.Shared;

namespace Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<IDatabaseContext, DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NaturaShopDatabase")));
            
            services.AddScoped<IProductRepository, ProductsRepository>();
            services.AddScoped<IPartnersRepository, PartnersRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();

            services.AddTransient<IDateService, DateService>();
            services.AddTransient<IGetProductsListQuery, GetProductsListQuery>();
            services.AddTransient<IGetPartnersListQuery, GetPartnersListQuery>();
            services.AddTransient<IGetCustomerListQuery, GetCustomerListQuery>();
            services.AddTransient<IGetSalesListQuery, GetSalesListQuery>();
            services.AddTransient<IGetSaleDetailQuery, GetSaleDetailQuery>();
            services.AddTransient<ICreateSaleCommand, CreateSaleCommand>();
            services.AddTransient<ISaleFactory, SaleFactory>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
