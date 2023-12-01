using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuickLap.Data.Context;
using QuickLap.Data.Repositories;
using QuickLap.Data.Repositories.Internal;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddQuickLapContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<QuickLapContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

    public static IServiceCollection AddQuickLapRepositories(this IServiceCollection services) 
        => services
            .AddScoped<IUserRepository, UserRepository>();
}