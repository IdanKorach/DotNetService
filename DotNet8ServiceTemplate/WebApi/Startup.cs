using Microsoft.Extensions.Options;
using Service;
using Model.DB;
using Service.Configuration;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton(configuration);
        SetDiRegistration(services);
        services.Configure<FeatureFlags>(configuration.GetSection("FeatureFlags"));
        services.AddSingleton<FeatureFlags>(serviceProvider =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<FeatureFlags>>();
            return options.Value;
        });
    }

    private static void SetDiRegistration(IServiceCollection services)
    {
        services.AddSingleton<IGenerateNumbersService, GenerateRandomNumbersService>();
        services.AddSingleton<IExampleService, ExampleService>();
        services.AddSingleton<IDbManager, DbManager>();
    }
}
