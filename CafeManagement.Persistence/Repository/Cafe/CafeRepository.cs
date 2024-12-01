using CafeManagement.Application.Repository;
using CafeManagement.Domain.Entities;
using CafeManagement.Persistence.Context;

namespace CafeManagement.Persistence.Repository;
public class CafeRepository(CafeManagementDBContext context) : BaseRepository<Cafe>(context), ICafeRepository
{
}
