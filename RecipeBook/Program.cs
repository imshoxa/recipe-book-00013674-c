using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Controllers;
using RecipeBook.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Student ID 00013674
builder.Services.AddDbContext<RecipeBookDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecipeBookConnectionStr")));
builder.Services.AddScoped<IRecipesRepository, RecipesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

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
