using Microsoft.EntityFrameworkCore;
using QuickLap.Data.Context;
using QuickLap.Data.Entities;
using QuickLap.Data.Exceptions;
using QuickLap.Data.Repositories.Internal;

namespace QuickLap.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly QuickLapContext _context;

    public UserRepository(QuickLapContext context)
    {
        _context = context;
    }

    public async Task CompleteProfileAsync(int id, string firstName, string lastName, CancellationToken cancellation = default)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id), cancellation) ?? throw new NotFoundException<User>(id);

        user.FirstName = firstName;
        user.LastName = lastName;

        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<bool> LoginAsync(string email, string password, CancellationToken cancellation = default) 
        => await _context.Users.AnyAsync(u => u.Email.Equals(email) && u.Password.Equals(password), cancellation);

    public async Task<int> RegisterUserAsync(string email, string password, CancellationToken cancellation = default)
    {
        var user = new User { Email = email, Password = password };
        await _context.Users.AddAsync(user, cancellation);
        await _context.SaveChangesAsync(cancellation);
        return user.Id;
    }
}
