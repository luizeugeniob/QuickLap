using Microsoft.EntityFrameworkCore;
using QuickLap.Data.Context;
using QuickLap.Data.Entities;
using QuickLap.Data.Exceptions;
using QuickLap.Data.Repositories.Internal;

namespace QuickLap.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly QuickLapContext _context;

    public ProductRepository(QuickLapContext context)
    {
        _context = context;
    }

    public async Task<int> AddProductAsync(string name, decimal price, CancellationToken cancellation = default)
    {
        var product = new Product { Name = name, Price = price };
        await _context.Products.AddAsync(product, cancellation);
        await _context.SaveChangesAsync(cancellation);
        return product.Id;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellation = default)
        => await _context.Products.ToListAsync(cancellation);

    public async Task<Product> GetByIdAsync(int id, CancellationToken cancellation = default)
        => await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id), cancellation) ?? throw new NotFoundException<Product>(id);
}
