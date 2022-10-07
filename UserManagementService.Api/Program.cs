using UserManagementService.Application;
using UserManagementService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configuration = builder.Configuration;
var environment = builder.Environment;

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

var app = builder.Build();

if (environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();

app.Run();
