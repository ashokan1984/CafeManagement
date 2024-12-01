using CafeManagement.Application.Repository;
using MediatR;

namespace CafeManagement.Application.Features.Employee.Delete
{
    public class DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommandRequest>
    {
        public async Task Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await Task.Run(() => employeeRepository.Delete(request.ID));
            await unitOfWork.Save(cancellationToken);
        }
    }
}
