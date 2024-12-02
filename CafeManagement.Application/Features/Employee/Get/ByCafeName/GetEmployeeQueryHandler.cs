using AutoMapper;
using CafeManagement.Application.Common.Exceptions;
using CafeManagement.Application.Repository;
using MediatR;
using System.Collections.Immutable;

namespace CafeManagement.Application.Features.Employee.Get.GetByCafeName;

public sealed class GetEmployeeQueryHandler(ICafeRepository cafeRepository, IMapper mapper) : IRequestHandler<GetEmployeeQueryRequest, ImmutableList<GetEmployeeQueryResponse>>
{
    public async Task<ImmutableList<GetEmployeeQueryResponse>> Handle(GetEmployeeQueryRequest request,
       CancellationToken cancellationToken)
    {
        var cafe = await cafeRepository.FirstOrDefault(x => x.Name.Trim().ToLower() == request.CafeName.Trim().ToLower(), y => y.Employees.Where(s => true))
                    ?? throw new NotFoundException("Cafe not found", request.CafeName);

        var employees = mapper.Map<List<GetEmployeeQueryResponse>>(cafe.Employees).OrderByDescending(o => o.NoOfDaysWorked).ToImmutableList();

        return employees;
    }
}
