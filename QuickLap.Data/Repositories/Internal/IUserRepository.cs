namespace QuickLap.Data.Repositories.Internal;

internal interface IUserRepository
{
    Task CompleteProfileAsync(int id, string firstName, string lastName, CancellationToken cancellation = default);
    Task<bool> LoginAsync(string email, string password, CancellationToken cancellation = default);
    Task<int> RegisterUserAsync(string email, string password, CancellationToken cancellation = default);
}
