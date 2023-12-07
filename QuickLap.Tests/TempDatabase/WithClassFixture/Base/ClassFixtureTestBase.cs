namespace QuickLap.Tests.TempDatabase.WithClassFixture.Base;

[CollectionDefinition("TempDatabaseShared")]
public class ClassFixtureTestBase : IClassFixture<TempDatabaseFixture>
{
    protected readonly TempDatabaseFixture Fixture;

    public ClassFixtureTestBase(TempDatabaseFixture fixture)
    {
        Fixture = fixture;
    }
}
