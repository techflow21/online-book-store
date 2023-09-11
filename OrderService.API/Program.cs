using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderService.Infrastructure.DataContext;
using OrderService.Infrastructure.Mappings;
using OrderService.Services.Implementations;
using OrderService.Services.Interfaces;
using RabbitMQSystem;
using System.Reflection;

namespace OrderService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<OrderDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderService.API", Version = "v1" });
            });

            builder.Services.AddTransient<IMessageManager, MessageManager>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();

            builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
            builder.Services.AddAutoMapper(Assembly.Load("OrderService.Infrastructure"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}