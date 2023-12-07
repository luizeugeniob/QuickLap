using Microsoft.EntityFrameworkCore;
using QuickLap.Data.Context;

namespace QuickLap.Tests.InMemory;

public class InMemoryDatabaseFixture : IDisposable
{
    public InMemoryDatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<QuickLapContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        Context = new QuickLapContext(options);
    }

    public QuickLapContext Context { get; private set; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {

    }
}
