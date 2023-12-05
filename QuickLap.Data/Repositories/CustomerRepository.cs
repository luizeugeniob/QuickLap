using Microsoft.EntityFrameworkCore;
using QuickLap.Data.Context;
using QuickLap.Data.Entities;
using QuickLap.Data.Exceptions;
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
        if (await _context.Customers.AnyAsync(u => u.Email.Equals(email), cancellation))
            throw new EntityAlreadyExistsException<Customer>(email);

        var customer = new Customer { FirstName = firstName, LastName = lastName, Email = email };
        await _context.Customers.AddAsync(customer, cancellation);
        await _context.SaveChangesAsync(cancellation);
        return customer.Id;
    }
}
