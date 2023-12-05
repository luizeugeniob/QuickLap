using QuickLap.Data.Entities;

namespace QuickLap.Data.Repositories.Internal;

internal interface IProductRepository
{
    Task<int> AddProductAsync(string name, decimal price, CancellationToken cancellation = default);
    Task<List<Product>> GetAllAsync(CancellationToken cancellation = default);
    Task<Product> GetByIdAsync(int id, CancellationToken cancellation = default);
}
