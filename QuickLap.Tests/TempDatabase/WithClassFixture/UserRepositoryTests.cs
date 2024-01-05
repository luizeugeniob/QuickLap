using QuickLap.Data.Context;
using QuickLap.Tests.TempDatabase.WithClassFixture.Base;

namespace QuickLap.Tests.TempDatabase.WithClassFixture;

[Collection("TempDatabaseShared")]
public class UserRepositoryTests : ClassFixtureTestBase
{
    public readonly QuickLapContext Context;

    public UserRepositoryTests(TempDatabaseFixture fixture) : base(fixture)
    {
        Context = fixture.Context;
    }

    private UserRepository GetRepository() => new(Context);

    [Fact]
    public async Task CompleteProfileAsync_ShouldUpdateUserDetails_WhenUserExists()
    {
        // Arrange
        var user = new User { Email = "email@email.com", Password = "123456789" };
        await Context.Users.AddAsync(user);
        await Context.SaveChangesAsync();

        // Act
        await GetRepository().CompleteProfileAsync(user.Id, "NewFirstName", "NewLastName");

        // Assert
        user.FirstName.Should().Be("NewFirstName");
        user.LastName.Should().Be("NewLastName");
    }

    [Fact]
    public async Task CompleteProfileAsync_ShouldThrowNotFoundException_WhenUserDoesNotExist()
    {
        // Arrange
        // Act
        // Assert
        await GetRepository()
            .Invoking(async x => await x.CompleteProfileAsync(int.MaxValue, "NewFirstName", "NewLastName"))
            .Should().ThrowAsync<NotFoundException<User>>();
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnTrue_WhenUserExistsWithMatchingCredentials()
    {
        // Arrange
        var user = new User { Email = "test@example.com", Password = "password123" };
        await Context.Users.AddAsync(user);
        await Context.SaveChangesAsync();

        // Act
        var result = await GetRepository().LoginAsync("test@example.com", "password123");

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnFalse_WhenUserDoesNotExistWithMatchingCredentials()
    {
        // Arrange
        // Act
        var result = await GetRepository().LoginAsync("nonexistent@example.com", "password123");

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task RegisterUserAsync_ShouldAddNewUserAndReturnUserId()
    {
        // Arrange
        var email = "newuser@example.com";
        var password = "password123";

        // Act
        var userId = await GetRepository().RegisterUserAsync(email, password);

        // Assert
        userId.Should().NotBe(0);
    }

    [Fact]
    public async Task RegisterUserAsync_ShouldThrowEntityAlreadyExistsException_WhenUserWithEmailAlreadyExists()
    {
        // Arrange
        var existingUser = new User { Email = "existing@example.com", Password = "existingPassword" };
        await Context.Users.AddAsync(existingUser);
        await Context.SaveChangesAsync();

        // Act
        // Assert
        await GetRepository()
            .Invoking(async x => await x.RegisterUserAsync("existing@example.com", "newPassword"))
            .Should().ThrowAsync<EntityAlreadyExistsException<User>>();
    }
}
