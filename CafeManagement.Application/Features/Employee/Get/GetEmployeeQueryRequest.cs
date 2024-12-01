using MediatR;
using System.Collections.Immutable;

namespace CafeManagement.Application.Features.Employee.Get
{
    public record class GetEmployeeQueryRequest(string CafeName) : IRequest<ImmutableList<GetEmployeeQueryResponse>>
    {
    }
}
