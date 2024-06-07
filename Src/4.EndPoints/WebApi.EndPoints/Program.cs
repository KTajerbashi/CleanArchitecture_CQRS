using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Application.Library.DIContainer;
using CleanArchitectureCQRS.CommandsDb.Library.Database;
using CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts;
using CleanArchitectureCQRS.QueriesDb.Library.Database;
using Microsoft.EntityFrameworkCore;
using WebApi.EndPoints.DIContainers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationDatabase(builder);
#region MediateR
builder.Services.AddApplication();
#endregion

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
