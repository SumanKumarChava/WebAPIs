using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Repositories;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI
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

            builder.Services.AddDbContext<NZWalksDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalks"));
            });

            builder.Services.AddScoped<IRegionRepository, RegionRepository>();
            builder.Services.AddScoped<IWalkRepository, WalkRepository>();
            builder.Services.AddScoped<IWalkDifficultyRepository, WalkDifficultyRepository>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddFluentValidation(configurationExpression: options => options.RegisterValidatorsFromAssemblyContaining(typeof(Program)));

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