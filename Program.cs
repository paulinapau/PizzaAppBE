using PizzaApp;
using PizzaApp.Repository;
using PizzaApp.Interfaces;
using PizzaApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IToppingRepository, ToppingRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
// Add services to the container.
builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseInMemoryDatabase("PizzaDb")); // Use in-memory database

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(cp => cp.AddPolicy("AllowAny", policy => policy
.AllowAnyHeader()
.AllowAnyOrigin()
.AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAny");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
