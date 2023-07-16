using Microsoft.EntityFrameworkCore;
using RBSsistemas.Data;
using RBSsistemas.Repositories;
using RBSsistemas.Repositories.Interfaces;

namespace RBSsistemas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var connectionStringMySql = builder.Configuration.GetConnectionString("ConnectionMySql");
            builder.Services.AddDbContext<RBSsistemasDBcontext>(options => options.UseMySql(
                connectionStringMySql, ServerVersion.Parse("10.4.27-MariaDB")
                )
            );

            builder.Services.AddScoped<IUsuarioRepositorie, UsuarioRepositorie>();
            builder.Services.AddScoped<IFornecedorRepositorie, FornecedorRepositorie>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("corspolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}