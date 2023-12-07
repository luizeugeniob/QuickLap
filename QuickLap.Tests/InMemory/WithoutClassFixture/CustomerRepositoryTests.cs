namespace QuickLap.Tests.InMemory.WithoutClassFixture;

public class CustomerRepositoryTests : InMemoryDatabaseFixture
{
    private CustomerRepository GetRepository() => new(Context);

    [Fact]
    public async Task RegisterCustomerAsync_ShouldRegisterCustomerAndReturnCustomerId()
    {
        // Arrange
        var firstName = "John";
        var lastName = "Doe";
        var email = "john.doe@example.com";

        // Act
        var customerId = await GetRepository().RegisterCustomerAsync(firstName, lastName, email);

        // Assert
        customerId.Should().NotBe(0);
        Context.Customers.Should().Contain(c => c.Id == customerId && c.FirstName == firstName && c.LastName == lastName && c.Email == email);
    }

    [Fact]
    public async Task RegisterCustomerAsync_ShouldThrowEntityAlreadyExistsException_WhenCustomerWithEmailAlreadyExists()
    {
        // Arrange
        var existingCustomer = new Customer { FirstName = "John", LastName = "Doe", Email = "existing@example.com" };
        Context.Customers.Add(existingCustomer);
        await Context.SaveChangesAsync();

        // Act
        // Assert
        await GetRepository()
            .Invoking(async x => await x.RegisterCustomerAsync("NewFirstName", "NewLastName", "existing@example.com"))
            .Should().ThrowAsync<EntityAlreadyExistsException<Customer>>();
    }
}
