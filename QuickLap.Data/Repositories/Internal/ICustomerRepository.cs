namespace QuickLap.Data.Repositories.Internal;

internal interface ICustomerRepository
{
    Task<int> RegisterCustomerAsync(string firstName, string lastName, string email, CancellationToken cancellation = default);
}
