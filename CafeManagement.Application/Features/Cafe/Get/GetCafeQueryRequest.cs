using MediatR;

namespace CafeManagement.Application.Features.Cafe.Get
{
    public sealed record GetCafeQueryRequest(string Location) : IRequest<IList<GetCafeQueryResponse>>;
}
