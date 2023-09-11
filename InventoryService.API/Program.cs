using InventoryService.Infrastructure.DataContext;
using InventoryService.Infrastructure.MappingProfile;
using InventoryService.Services.Implementations;
using InventoryService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RabbitMQSystem;
using System.Reflection;

namespace InventoryService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<InventoryDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryService.API", Version = "v1" });
            });

            builder.Services.AddTransient<IMessageManager, MessageManager>();
            builder.Services.AddScoped<IBookService, BookService>();

            builder.Services.AddAutoMapper(typeof(InventoryMappingProfile));
            builder.Services.AddAutoMapper(Assembly.Load("InventoryService.Infrastructure"));

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