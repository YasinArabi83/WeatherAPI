
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using WeatherAPI.Interfaces;
using WeatherAPI.Services;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(
    outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}"
    ).CreateBootstrapLogger();

try
{
    Log.Information("Starting up...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("tokens.json", optional: false, reloadOnChange: true);

    builder.Services.AddSerilog((services, lc) =>
    {
        lc
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console(
            outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}"
            )
        .WriteTo.File(
            new RenderedCompactJsonFormatter(),
            Path.Combine(Directory.GetCurrentDirectory(), "Logs", "error-log.json"),
            restrictedToMinimumLevel: LogEventLevel.Error,
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 30,
            encoding: System.Text.Encoding.UTF8
    );
    });

    builder.Services.AddScoped<IApiFetcher, ApiFetcher>();
    builder.Services.AddHttpClient<IOpenWeatherServices, OpenWeatherServices>(client =>
    {

        client.BaseAddress = new Uri(builder.Configuration["OpenWeather:BaseUrl"]
            ?? throw new NullReferenceException("The 'BaseUrl' configuration value is missing. Please ensure it is defined in the application settings."));
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("User-Agent", "WeatherAPI");
    });

    builder.Services.AddControllers();

    builder.Services.AddOpenApi("v1");

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.Information("Shutting down...");
    Log.CloseAndFlush();
}

