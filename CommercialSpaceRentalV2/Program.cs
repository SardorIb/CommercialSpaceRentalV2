using CommercialSpaceRentalV2.Middlewares;
using CommercialSpaceRentalV2.Repositories;
using CommercialSpaceRentalV2.Services.Implementation;
using CommercialSpaceRentalV2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sensirion.Data.DB;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Add services
// --------------------
builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
  options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register SQLHelper
builder.Services.AddScoped<SQLHelper>(sp =>
  new SQLHelper(
    new SensiConnectionStringBuilder(
      "KR-SEL-L-100122",
      "master",
      true,
      "CommercialSpaceRental"
    ).ConnectionString
  )
);
builder.Services.AddScoped<AuditLogRepository>();
// Dependency injection for repositories and services
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IUser, UserServiceImplemetation>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ClientInfoService>();

var app = builder.Build();

// --------------------
// Middleware pipeline
// --------------------
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");     // *********

app.Run();
