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
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowReactApp"); // Before app.UseRouting()
app.UseAuthorization();

app.MapControllers();

app.Run();
