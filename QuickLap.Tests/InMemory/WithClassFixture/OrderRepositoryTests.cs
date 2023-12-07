using Microsoft.EntityFrameworkCore;
using QuickLap.Tests.InMemory.WithClassFixture.Base;

namespace QuickLap.Tests.InMemory.WithClassFixture;

[Collection("InMemoryDatabaseShared")]
public class OrderRepositoryTests : SharedInMemory
{
    public OrderRepositoryTests(InMemoryDatabaseFixture fixture) : base(fixture)
    {
    }

    private OrderRepository GetRepository() => new(Context);

    [Fact]
    public async Task AddOrderItemAsync_ShouldAddOrderItem_WhenOrderDoesntHaveProductYet()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "ExistingProduct", Price = 29.99m };
        var order = new Order { CustomerId = 1 };

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
        var product = new Product { Id = 2, Name = "ExistingProduct", Price = 29.99m };
        var order = new Order { CustomerId = 1 };

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
        var customerId = 1;

        // Act
        var orderId = await GetRepository().CreateOrderAsync(customerId);

        // Assert
        orderId.Should().NotBe(0);
        var order = Context.Orders.Where(o => o.Id == orderId).Should().ContainSingle().Subject;
        order!.CustomerId.Should().Be(customerId);
    }
}
