using Contracts;
using FluentValidation;
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
        services.AddValidatorsFromAssemblyContaining<GenerateNumbersRequest>();
        SetDiRegistration(services);
        var featureFlags = configuration.GetSection("FeatureFlags").Get<FeatureFlags>();
        services.AddSingleton(featureFlags);
    }

    private static void SetDiRegistration(IServiceCollection services)
    {
        services.AddSingleton<IGenerateNumbersService, GenerateRandomNumbersService>();
        services.AddSingleton<IExampleService, ExampleService>();
        services.AddSingleton<IDbManager, DbManager>();
    }
}
