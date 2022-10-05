using UserManagementService.Application;
using UserManagementService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

var context = app.Services.GetService<UsersDbContext>();
DbInitializer.Initialize(context);

app.Run();
