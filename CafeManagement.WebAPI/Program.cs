using CafeManagement.Application;
using CafeManagement.Persistence;
using CafeManagement.Persistence.Context;
using CafeManagement.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.ConfigureApiBehavior();

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()  // Allows any origin
            .AllowAnyMethod()  // Allows any HTTP method
            .AllowAnyHeader()); // Allows any HTTP header
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<CafeManagementDBContext>();
dataContext?.Database.EnsureCreated();

app.UseSwagger();
app.UseSwaggerUI();
app.UseErrorHandler();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();