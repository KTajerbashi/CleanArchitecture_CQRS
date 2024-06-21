using CleanArchitectureCQRS.Application.Library.DIContainer;
using CleanArchitectureCQRS.ContextDatabase.Library.DIContainer;
using WebApi.EndPoints.DIContainers;
using WebApi.EndPoints.Middlewares;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true)
    .AddEnvironmentVariables();

//Register Application layer and Event Store layer from Infrastructure here
builder.Services.AddApplication();
builder.Services.AddEventStore(builder.Configuration);
builder.Services.AddApplicationDatabase(builder);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionsHandling();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
