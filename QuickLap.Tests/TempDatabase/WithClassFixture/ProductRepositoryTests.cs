using QuickLap.Data.Context;
using QuickLap.Tests.TempDatabase.WithClassFixture.Base;

namespace QuickLap.Tests.TempDatabase.WithClassFixture;

[Collection("TempDatabaseShared")]
public class ProductRepositoryTests : ClassFixtureTestBase
{
    public readonly QuickLapContext Context;

    public ProductRepositoryTests(TempDatabaseFixture fixture) : base(fixture)
    {
        Context = fixture.Context;
    }

    private ProductRepository GetRepository() => new(Context);

    [Fact]
    public async Task AddProductAsync_ShouldAddProductAndReturnProductId()
    {
        // Arrange
        var productName = "TestProduct";
        var productPrice = 29.99m;

        // Act
        var productId = await GetRepository().AddProductAsync(productName, productPrice);

        // Assert
        productId.Should().NotBe(0);
        Context.Products.Should().Contain(p => p.Id == productId && p.Name == productName && p.Price == productPrice);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfProducts()
    {
        // Arrange
        var products = new List<Product>
        {
            new Product { Name = "Product1", Price = 19.99m },
            new Product { Name = "Product2", Price = 29.99m },
            new Product { Name = "Product3", Price = 39.99m }
        };
        await Context.Products.AddRangeAsync(products);
        await Context.SaveChangesAsync();

        // Act
        var result = await GetRepository().GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().Contain(products);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange
        var existingProduct = new Product { Name = "ExistingProduct", Price = 49.99m };
        await Context.Products.AddAsync(existingProduct);
        await Context.SaveChangesAsync();

        // Act
        var result = await GetRepository().GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(existingProduct);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrowNotFoundException_WhenProductDoesNotExist()
    {
        // Arrange
        // Act
        // Assert
        await GetRepository()
            .Invoking(async x => await x.GetByIdAsync(int.MaxValue))
            .Should().ThrowAsync<NotFoundException<Product>>();
    }
}
