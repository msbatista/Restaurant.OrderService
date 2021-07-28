using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Restaurant.OrderService.Domain.Interfaces.Repositories;
using Restaurant.OrderService.Infrastructure.DataAccess.Context;
using Restaurant.OrderService.Infrastructure.DataAccess.Repository;
using Restaurant.OrderService.Infrastructure.Middleware.Filters;

namespace Restaurant.OrderService
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

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant.OrderService", Version = "v1" });
            });

            services.AddDbContext<RestaurantDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("RestaurantDb");
                options.UseSqlServer(connectionString, option =>
                {
                    option.CommandTimeout(180);
                }).UseLazyLoadingProxies();
            });

            services.AddScoped<IClientRepository, ClientRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant.OrderService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseExceptionHandler(task => task.Run(async context => await HttpGlobalExceptionFilter.OnHttpException(context)));
        }
    }
}
