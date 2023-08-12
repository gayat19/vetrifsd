using Microsoft.EntityFrameworkCore;
using TourAPI.Contexts;
using TourAPI.Interfaces;
using TourAPI.Models;
using TourAPI.Repos;
using TourAPI.Services;

namespace TourAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region PreDefinedService
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region UserDefinedServicesInjection
            builder.Services.AddScoped<IRepo<int, Tour>, TourDbRepo>();
            builder.Services.AddScoped<ICustomerTourService,TourService>();
            builder.Services.AddScoped<IAgentTourService, TourService>();
            builder.Services.AddDbContext<TravelContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("travelCon"));
            });
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}