using AutoMapper;
using CafeManagement.Application.Repository;
using CafeManagement.Domain.Entities;
using MediatR;

namespace CafeManagement.Application.Features.Cafe.Get;

public sealed class GetCafeQueryHandler(ICafeRepository cafeRepository, IMapper mapper) : IRequestHandler<GetCafeQueryRequest, IList<GetCafeQueryResponse>>
{
    public async Task<IList<GetCafeQueryResponse>> Handle(GetCafeQueryRequest request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Cafe> cafes = string.IsNullOrEmpty(request.Location)
            ? await cafeRepository.GetAllNoTracking(includes => includes.Employees.Where(s => true))
            : await cafeRepository.GetAllNoTracking(x => x.Location == request.Location, includes => includes.Employees.Where(s => true));
        return mapper.Map<List<GetCafeQueryResponse>>(cafes);
    }
}
