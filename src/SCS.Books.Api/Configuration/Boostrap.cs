using BookStore.Contract;
using BookStore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace BookStore.Configuration
{
	public static class Boostrap
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		public static void UseConfigurationServices(IServiceCollection services)
		{
			services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists")); // new
			services.AddControllers();//.AddOData(opt => opt.AddRouteComponents("odata", GetEdmModel()).EnableQueryFeatures());
			services.AddSwaggerGen();
		}

		public static void UseConfiguration(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
				options.RoutePrefix = string.Empty;
			});
		}

		private static IEdmModel GetEdmModel()
		{
			ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
			builder.EntitySet<IBook>("Books");
			builder.EntitySet<IPress>("Presses");
			return builder.GetEdmModel();
		}
	}
}
