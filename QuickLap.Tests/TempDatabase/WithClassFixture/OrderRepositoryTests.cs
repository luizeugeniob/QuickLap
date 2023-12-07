using Microsoft.EntityFrameworkCore;
using QuickLap.Tests.TempDatabase.WithClassFixture.Base;

namespace QuickLap.Tests.TempDatabase.WithClassFixture;

[Collection("TempDatabaseShared")]
public class OrderRepositoryTests : SharedTemp
{
    public OrderRepositoryTests(TempDatabaseFixture fixture) : base(fixture)
    {

    }

    private OrderRepository GetRepository() => new(Context);

    [Fact]
    public async Task AddOrderItemAsync_ShouldAddOrderItem_WhenOrderDoesntHaveProductYet()
    {
        // Arrange
        var customer = new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "customer1@example.com" };
        var product = new Product { Id = 1, Name = "ExistingProduct", Price = 29.99m };
        var order = new Order { CustomerId = customer.Id };

        await Context.Customers.AddAsync(customer);
        await Context.Products.AddAsync(product);
        await Context.Orders.AddAsync(order);
        await Context.SaveChangesAsync();

        var quantityToBeAdded = 2;

        // Act
        await GetRepository().AddOrderItemAsync(order.Id, product.Id, quantityToBeAdded);

        // Assert
        order = Context.Orders.Include(o => o.OrderItems).Where(o => o.Id.Equals(order.Id)).Should().ContainSingle().Subject;
        order.Should().NotBeNull();
        var orderItem = order!.OrderItems.Should().ContainSingle().Subject;
        orderItem.ProductId.Should().Be(product.Id);
        orderItem.Quantity.Should().Be(quantityToBeAdded);
    }

    [Fact]
    public async Task AddOrderItemAsync_ShouldIncrementOrderItem_WhenOrderAlreadyHasProduct()
    {
        // Arrange
        var customer = new Customer { Id = 2, FirstName = "John", LastName = "Doe", Email = "customer2@example.com" };
        var product = new Product { Id = 2, Name = "ExistingProduct", Price = 29.99m };
        var order = new Order { CustomerId = customer.Id };

        await Context.Customers.AddAsync(customer);
        await Context.Products.AddAsync(product);
        await Context.Orders.AddAsync(order);
        await Context.SaveChangesAsync();

        var existingQuantity = 2;
        await GetRepository().AddOrderItemAsync(order.Id, product.Id, existingQuantity);

        var quantityToBeAdded = 2;

        // Act
        await GetRepository().AddOrderItemAsync(order.Id, product.Id, quantityToBeAdded);

        // Assert
        order = Context.Orders.Include(o => o.OrderItems).Where(o => o.Id.Equals(order.Id)).Should().ContainSingle().Subject;
        var orderItem = order!.OrderItems.Should().ContainSingle().Subject;
        orderItem.ProductId.Should().Be(product.Id);
        orderItem.Quantity.Should().Be(existingQuantity + quantityToBeAdded);
    }

    [Fact]
    public async Task CreateOrderAsync_ShouldCreateOrderAndReturnOrderId()
    {
        // Arrange
        var customer = new Customer { Id = 3, FirstName = "John", LastName = "Doe", Email = "customer3@example.com" };
        await Context.Customers.AddAsync(customer);
        await Context.SaveChangesAsync();

        // Act
        var orderId = await GetRepository().CreateOrderAsync(customer.Id);

        // Assert
        orderId.Should().NotBe(0);
        var order = Context.Orders.Where(o => o.Id == orderId).Should().ContainSingle().Subject;
        order!.CustomerId.Should().Be(customer.Id);
    }
}
