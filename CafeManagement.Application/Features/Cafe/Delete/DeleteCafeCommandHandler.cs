using CafeManagement.Application.Repository;
using MediatR;

namespace CafeManagement.Application.Features.Cafe.Delete
{
    public class DeleteCafeCommandHandler(IUnitOfWork unitOfWork, ICafeRepository cafeRepository) : IRequestHandler<DeleteCafeCommandRequest>
    {
        public async Task Handle(DeleteCafeCommandRequest request, CancellationToken cancellationToken)
        {
           await Task.Run(() => cafeRepository.Delete(request.ID));
           await unitOfWork.Save(cancellationToken);
        }
    }
}
