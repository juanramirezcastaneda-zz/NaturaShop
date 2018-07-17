using Application.Customers.Queries.GetCustomersList;
using Application.Interfaces.Persistence;
using Application.Partners.Queries.GetPartnersList;
using Application.Products.Queries.GetProductsList;
using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Customers;
using Persistence.Partners;
using Persistence.Products;
using Persistence.Sales;
using Persistence.Shared;

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
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddDbContext<IDatabaseContext, DatabaseContext>();

			services.AddScoped<IProductRepository, ProductsRepository>();
			services.AddScoped<IPartnersRepository, PartnersRepository>();
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<ISalesRepository, SalesRepository>();
			
			services.AddTransient<IGetProductsListQuery, GetProductsListQuery>();
			services.AddTransient<IGetPartnersListQuery, GetPartnersListQuery>();
			services.AddTransient<IGetCustomerListQuery, GetCustomerListQuery>();
			services.AddTransient<IGetSalesListQuery, GetSalesListQuery>();
			services.AddTransient<IGetSaleDetailQuery, GetSaleDetailQuery>();
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
