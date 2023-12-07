using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuickLap.Data.Context;

namespace QuickLap.Tests.TempDatabase;

public class TempDatabaseFixture : IDisposable
{
    private readonly string _databaseName = $"dbTest_{Guid.NewGuid():N}";

    public TempDatabaseFixture()
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<QuickLapContext>(options =>
                options.UseNpgsql($"Host=localhost;Port=5432;Database={_databaseName};Username=postgres;Password=postgres;"))
            .BuildServiceProvider();

        Context = serviceProvider.GetRequiredService<QuickLapContext>();
        Context.Database.EnsureCreated();
    }

    public QuickLapContext Context { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        Context.Database.EnsureDeleted();
    }
}
