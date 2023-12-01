using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuickLap.Data.Context;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddQuickLapContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<QuickLapContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
}