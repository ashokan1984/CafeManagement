using MediatR;

namespace CafeManagement.Application.Features.Employee.Delete
{
    public sealed record class DeleteEmployeeCommandRequest(Guid ID) : IRequest;
}
