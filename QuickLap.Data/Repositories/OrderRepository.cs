using Microsoft.EntityFrameworkCore;
using QuickLap.Data.Context;
using QuickLap.Data.Entities;
using QuickLap.Data.Exceptions;
using QuickLap.Data.Repositories.Internal;

namespace QuickLap.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly QuickLapContext _context;

    public OrderRepository(QuickLapContext context)
    {
        _context = context;
    }

    public async Task AddOrderItemAsync(int orderId, int productId, int quantity, CancellationToken cancellation = default)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id.Equals(orderId), cancellation) ?? throw new NotFoundException<Order>(orderId);

        var orderItem = order.OrderItems.Find(oi => oi.ProductId.Equals(productId));
        if (orderItem is not null)
        {
            orderItem.Quantity += quantity;
        }
        else
        {
            order.OrderItems.Add(
                new OrderItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                });
        }

        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<int> CreateOrderAsync(int customerId, CancellationToken cancellation = default)
    {
        var order = new Order { CustomerId = customerId };

        await _context.Orders.AddAsync(order, cancellation);
        await _context.SaveChangesAsync(cancellation);

        return order.Id;
    }
}
