using MediatR;
using System.Collections.Immutable;

namespace CafeManagement.Application.Features.Employee.Get.GetByCafeId
{
    public record class GetEmployeeByCafeIdQueryRequest(Guid CafeId) : IRequest<ImmutableList<GetEmployeeQueryResponse>>
    {
    }
}
