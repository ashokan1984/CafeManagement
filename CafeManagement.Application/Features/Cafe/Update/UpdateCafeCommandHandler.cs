using AutoMapper;
using CafeManagement.Application.Common.Exceptions;
using CafeManagement.Application.Repository;
using MediatR;

namespace CafeManagement.Application.Features.Cafe.Update;

public class UpdateCafeCommandHandler(IUnitOfWork unitOfWork, ICafeRepository cafeRepository, IMapper mapper) : IRequestHandler<UpdateCafeCommandRequest>
{
    public async Task Handle(UpdateCafeCommandRequest request, CancellationToken cancellationToken)
    {
        // Retrieve the existing visitor from the repository
        var cafe = await cafeRepository.Get(request.ID, cancellationToken) ?? throw new NotFoundException("Cafe not found", request.ID);

        // Map the updated values from the request onto the existing visitor entity
        mapper.Map(request, cafe);

        // Perform the update in the repository
        cafeRepository.Update(cafe);

        // Save changes via UnitOfWork
        await unitOfWork.Save(cancellationToken);
    }
}
