using CafeManagement.Application.Repository;
using CafeManagement.Domain.Entities;
using CafeManagement.Persistence.Context;

namespace CafeManagement.Persistence.Repository;

public class EmployeeRepository(CafeManagementDBContext context) : BaseRepository<Employee>(context), IEmployeeRepository
{
}
