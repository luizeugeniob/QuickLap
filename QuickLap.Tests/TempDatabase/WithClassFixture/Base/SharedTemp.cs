using QuickLap.Data.Context;

namespace QuickLap.Tests.TempDatabase.WithClassFixture.Base;

public abstract class SharedTemp
{
    public readonly QuickLapContext Context;

    protected SharedTemp(TempDatabaseFixture fixture)
    {
        Context = fixture.Context;
    }
}
