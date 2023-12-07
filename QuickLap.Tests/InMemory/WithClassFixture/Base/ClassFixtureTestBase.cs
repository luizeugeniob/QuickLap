namespace QuickLap.Tests.InMemory.WithClassFixture.Base;

[CollectionDefinition("InMemoryDatabaseShared")]
public class ClassFixtureTestBase : IClassFixture<InMemoryDatabaseFixture>
{
    protected readonly InMemoryDatabaseFixture Fixture;

    public ClassFixtureTestBase(InMemoryDatabaseFixture fixture)
    {
        Fixture = fixture;
    }
}
