using Jtbuk.VerticalArchitecture.Common.Swagger;
using Jtbuk.VerticalArchitecture.Features.Weather;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();

builder.AddSwagger();
builder.AddWeatherFeature();

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseWeatherFeature();
app.Run();
