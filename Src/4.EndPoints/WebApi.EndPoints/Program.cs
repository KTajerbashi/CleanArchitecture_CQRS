using CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureCQRS.Application.Library.People.Commands;
using CleanArchitectureCQRS.Application.Library.People.Handler;
using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.Application.Library.People.Queries;
using CleanArchitectureCQRS.Application.Library.DIContainer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region ContextDb
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
});
#endregion
#region MediateR
// Adding MediatR

builder.Services.AddScoped<IApplicationContext, ApplicationContext>();
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
