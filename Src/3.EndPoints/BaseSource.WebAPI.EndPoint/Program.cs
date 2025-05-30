using BaseSource.WebAPI.EndPoint;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebAPIService();

var app = builder.Build();

app.UseWebAPIService();

app.Run();
