using BaseSource.WebAPI.EndPoint;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebAPIService();

var app = builder.Build();

await app.InitialiseDatabaseAsync();

app.UseWebAPIService();

app.Run();
