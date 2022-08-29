using BookStore.Data;
using Infrastructure.Data.Repositores;
using Infrastructure.Data.Repositores.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore.Configuration
{
	public static class Boostrap
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		public static void UseConfigurationServices(IServiceCollection services)
		{
			services.AddSingleton<IBooksRepository, BooksRepository>(); // new			
			services.AddControllers();
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

	}
}
