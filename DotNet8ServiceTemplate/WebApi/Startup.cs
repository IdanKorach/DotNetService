using Service;
using Model.DB;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton(configuration);
        SetDiRegistration(services);
    }

    private static void SetDiRegistration(IServiceCollection services)
    {
        services.AddSingleton<IGenerateRandomNumbersService, GenerateRandomNumbersService>();
        services.AddSingleton<IExampleService, ExampleService>();
        services.AddSingleton<IDbManager, DbManager>();
    }
}
