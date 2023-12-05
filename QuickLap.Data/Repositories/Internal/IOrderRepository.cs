namespace QuickLap.Data.Repositories.Internal;

internal interface IOrderRepository
{
    Task<int> CreateOrderAsync(int customerId, CancellationToken cancellation = default);
    Task AddOrderItemAsync(int orderId, int productId, int quantity, CancellationToken cancellation = default);
}
