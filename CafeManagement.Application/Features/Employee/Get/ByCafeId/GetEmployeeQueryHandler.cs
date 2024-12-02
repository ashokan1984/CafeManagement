using AutoMapper;
using CafeManagement.Application.Common.Exceptions;
using CafeManagement.Application.Repository;
using MediatR;
using System.Collections.Immutable;

namespace CafeManagement.Application.Features.Employee.Get.GetByCafeId;

public sealed class GetEmployeeByCafeIdQueryHandler(ICafeRepository cafeRepository, IMapper mapper) : IRequestHandler<GetEmployeeByCafeIdQueryRequest, ImmutableList<GetEmployeeQueryResponse>>
{
    public async Task<ImmutableList<GetEmployeeQueryResponse>> Handle(GetEmployeeByCafeIdQueryRequest request,
       CancellationToken cancellationToken)
    {
        var cafe = await cafeRepository.FirstOrDefault(x => x.ID == request.CafeId, y => y.Employees.Where(s => true))
                    ?? throw new NotFoundException("Cafe not found", request.CafeId);

        var employees = mapper.Map<List<GetEmployeeQueryResponse>>(cafe.Employees).OrderByDescending(o => o.NoOfDaysWorked).ToImmutableList();

        return employees;
    }
}
