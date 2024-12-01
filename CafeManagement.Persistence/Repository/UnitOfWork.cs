using CafeManagement.Persistence.Context;
using CafeManagement.Application.Repository;

namespace CafeManagement.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly CafeManagementDBContext _context;

    public UnitOfWork(CafeManagementDBContext context)
    {
        _context = context;
    }
    public Task Save(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
