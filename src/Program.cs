using Jtbuk.VerticalArchitecture.Common.Swagger;
using Jtbuk.VerticalArchitecture.Features.Weather;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();

builder.AddSwagger();
builder.AddWeatherFeature();

var app = builder.Build();

// In a real production application it's unlikely that you'd run migrations on startup like this, as it doesn't scale
app.RunMigrations(); 
app.UseCustomExceptionHandler();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseWeatherFeature();
app.Run();
