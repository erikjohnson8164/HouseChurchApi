using HouseChurchApi.Contexts;
using HouseChurchApi.Interfaces;
using HouseChurchApi.RepositoryClasses;
using Microsoft.EntityFrameworkCore;
using HouseChurchApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChurchDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ChurchConnection")));
builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped<IPrayerRequestRepository, PrayerRequestRepository>();
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
