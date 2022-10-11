using UserManagementService.Application;
using UserManagementService.DataAccess;
using UserManagementService.Infrastructure.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configuration = builder.Configuration;
var environment = builder.Environment;

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

builder.Services.RegisterRabbitInfrastructure(configuration);
builder.Services.RegisterRabbitResources(configuration);

var app = builder.Build();

if (environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();

app.Run();
