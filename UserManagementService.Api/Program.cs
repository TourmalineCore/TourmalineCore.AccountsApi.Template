using UserManagementService.Application;
using UserManagementService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configuration = builder.Configuration;
var environment = builder.Environment;

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

app.Run();
