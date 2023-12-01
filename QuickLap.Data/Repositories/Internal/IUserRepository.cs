namespace QuickLap.Data.Repositories.Internal;

internal interface IUserRepository
{
    Task CompleteProfileAsync(int id, string firstName, string lastName, CancellationToken cancellation);
    Task<bool> LoginAsync(string email, string password, CancellationToken cancellation);
    Task<int> RegisterUserAsync(string email, string password, CancellationToken cancellation);
}
