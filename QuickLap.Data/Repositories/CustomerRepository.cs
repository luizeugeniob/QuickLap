using QuickLap.Data.Context;
using QuickLap.Data.Entities;
using QuickLap.Data.Repositories.Internal;

namespace QuickLap.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly QuickLapContext _context;

    public CustomerRepository(QuickLapContext context)
    {
        _context = context;
    }

    public async Task<int> RegisterCustomerAsync(string firstName, string lastName, string email, CancellationToken cancellation = default)
    {
        var customer = new Customer { FirstName = firstName, LastName = lastName, Email = email };
        await _context.Customers.AddAsync(customer, cancellation);
        await _context.SaveChangesAsync(cancellation);
        return customer.Id;
    }
}
