using QuickLap.Data.Context;

namespace QuickLap.Tests.InMemory.WithClassFixture.Base;

public abstract class SharedInMemory
{
    public readonly QuickLapContext Context;

    protected SharedInMemory(InMemoryDatabaseFixture fixture)
    {
        Context = fixture.Context;
    }
}
