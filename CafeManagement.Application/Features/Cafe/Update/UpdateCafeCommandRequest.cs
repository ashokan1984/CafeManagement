using MediatR;

namespace CafeManagement.Application.Features.Cafe.Update
{
    public sealed record UpdateCafeCommandRequest(Guid ID, string Name, string Description, Image Logo, string Location) : IRequest;

}
