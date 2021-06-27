using DeliveryUpdate.Repository;
using DeliveryUpdate.Service.Customer;
using DeliveryUpdate.Service.Order;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace DeliveryUpdate.Api
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
            services.AddDbContext<OrderContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                 ServiceLifetime.Scoped);

            // Classes
            services.AddSingleton<CustomerApiConfiguration>();

            // Repository
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Services
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Delivery Update API",
                    Version = "v1",
                    Description = "API to retrieve the most recent order for a specified customer.",
                    Contact = new OpenApiContact
                    {
                        Name = "Luke Parkinson",
                        Email = "parkinson.lukej@gmail.com",
                        Url = new Uri("https://github.com/lukejparkinson/MMT_Test"),
                    },
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "DeliveryUpdate.Api.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Delivery Update API");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
