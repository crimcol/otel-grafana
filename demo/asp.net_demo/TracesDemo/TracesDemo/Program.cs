using TracesDemo;
using TracesDemo.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Logs, Traces, and Metrics
builder.AddAppTelemetry();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapWeatherForecast();
app.MapExternalData();

app.Run();