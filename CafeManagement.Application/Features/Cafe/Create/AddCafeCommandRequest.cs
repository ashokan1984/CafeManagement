using MediatR;

namespace CafeManagement.Application.Features.Cafe.Create
{
    public sealed record AddCafeCommandRequest ( string Name, string Description, Image Logo, string Location) : IRequest<AddCafeCommandResponse>;

    
}
