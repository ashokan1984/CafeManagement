using MediatR;

namespace CafeManagement.Application.Features.Cafe.Delete
{
    public sealed record class DeleteCafeCommandRequest(Guid ID) : IRequest;
   
}
