using AutoMapper;
using CafeManagement.Application.Repository;
using MediatR;

namespace CafeManagement.Application.Features.Cafe.Create
{
    public sealed class AddCafeCommandHandler(IUnitOfWork unitOfWork, ICafeRepository cafeRepository, IMapper mapper) : IRequestHandler<AddCafeCommandRequest, AddCafeCommandResponse>
    {

        public async Task<AddCafeCommandResponse> Handle(AddCafeCommandRequest request,
          CancellationToken cancellationToken)
        {
            var cafe = mapper.Map<Domain.Entities.Cafe>(request);

            cafeRepository.Create(cafe);
            await unitOfWork.Save(cancellationToken);

            return mapper.Map<AddCafeCommandResponse>(cafe);
        }

    }
}
