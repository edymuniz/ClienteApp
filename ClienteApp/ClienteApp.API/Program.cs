using ClienteApp.Application.Cliente.Commands.Interface;
using ClienteApp.Application.Cliente.Commands.Service;
using ClienteApp.Application.Cliente.Queries.Interface;
using ClienteApp.Application.Cliente.Queries.Service;
using ClienteApp.Domain.Repository.Cliente.Adapter;
using ClienteApp.Domain.Repository.Cliente.SQL;
using ClienteApp.Infrastructure.Adapter.Cliente;
using ClienteApp.Infrastructure.Data;
using ClienteApp.Infrastructure.Repository.Cliente;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Text.Json.Serialization;

namespace ClienteApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()  
                          .AllowAnyHeader()  
                          .AllowAnyMethod(); 
                });
            });

            // SQL Server
            builder.Services.AddDbContext<ClienteDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
            });

            // MongoDB
            builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var connectionString = builder.Configuration.GetConnectionString("MongoConnection");
                return new MongoClient(connectionString);
            });

            builder.Services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var databaseName = builder.Configuration["MongoDatabaseName"];
                return client.GetDatabase(databaseName);
            });

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });


            // AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // Services
            builder.Services.AddScoped<IGetClienteQuery, GetClienteQuery>();
            builder.Services.AddScoped<ICreateClienteCommand, CreateClienteCommand>();
            builder.Services.AddScoped<IUpdateClienteCommand, UpdateClienteCommand>();
            builder.Services.AddScoped<IDeleteClienteCommand, DeleteClienteCommand>();

            // Repositories
            builder.Services.AddScoped<IMongoGetClienteRepository, MongoGetClienteRepository>();
            builder.Services.AddScoped<ICreateClienteRepository, CreateClienteRepository>();
            builder.Services.AddScoped<IUpdateClienteRepository, UpdateClienteRepository>();
            builder.Services.AddScoped<IDeleteClienteRepository, DeleteClienteRepository>();

            // Adapters
            builder.Services.AddScoped<IMongoCreateClienteRepository, MongoCreateClienteRepository>();
            builder.Services.AddScoped<IMongoDeleteClienteRepository, MongoDeleteClienteRepository>();
            builder.Services.AddScoped<IMongoUpdateClienteRepository, MongoUpdateClienteRepository>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("AllowAll");

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
