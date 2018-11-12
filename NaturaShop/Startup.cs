using System;
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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Customers;
using Persistence.Partners;
using Persistence.Products;
using Persistence.Sales;
using Persistence.Shared;
using React.AspNet;

namespace NaturaShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddMvc();
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

	        return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Initialise ReactJS.NET. Must be before static files.
            app.UseReact(config =>
            {
				// If you want to use server-side rendering of React components,
				// add all the necessary JavaScript files here. This includes
				// your components as well as all of their dependencies.
				// See http://reactjs.net/ for more information. Example:
	            //config
	            //  .AddScript("~/Scripts/Second.jsx");

	            // If you use an external build too (for example, Babel, Webpack,
	            // Browserify or Gulp), you can improve performance by disabling
	            // ReactJS.NET's version of Babel and loading the pre-transpiled
	            // scripts. Example:
	            //config
	            //  .SetLoadBabel(false)
	            //  .AddScriptWithoutTransform("~/Scripts/bundle.server.js");
            });
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
