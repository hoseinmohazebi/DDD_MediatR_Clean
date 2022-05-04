using DDD.API.Configuration.Middalware.ExceptionHandler;
using DDD.Product.Infrastructure;
using DDD.Product.Infrastructure.Persistence;
using DDD.UserAccess.Application.Models.Jwt;
using DDD.UserAccess.Infrastructure;
using DDD.UserAccess.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtModel>(builder.Configuration.GetSection(nameof(JwtModel)));

builder.Services.AddUserAccessServices(builder.Configuration);
builder.Services.AddProductServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExceptiontusMiddleware();

app.UseAuthorization();
app.UseAuthentication();
app.ApplyUserAccessMigration();
app.ApplyProductMigration();
app.MapControllers();
app.Run();
