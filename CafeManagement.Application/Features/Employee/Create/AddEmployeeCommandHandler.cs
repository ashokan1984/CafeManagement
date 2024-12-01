using AutoMapper;
using CafeManagement.Application.Common.Exceptions;
using CafeManagement.Application.Repository;
using MediatR;

namespace CafeManagement.Application.Features.Employee.Create
{
    public class AddEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
        ICafeRepository cafeRepository, IEmployeeRepository employeeRepository) : IRequestHandler<AddEmployeeCommandRequest, AddEmployeeCommandResponse>
    {
        public async Task<AddEmployeeCommandResponse> Handle(AddEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            _ = await cafeRepository.Get(request.CafeId, cancellationToken) ?? throw new NotFoundException("Cafe not found", request.CafeId);

            var existingEmployee = await employeeRepository.FirstOrDefault(emp => emp.EmployeeId.ToLower().Equals(request.EmployeeId.ToLower()));
            if (existingEmployee != null)
            {
                throw new AlreadyExistsException(nameof(request.EmployeeId), request.EmployeeId);
            }
            var employee = mapper.Map<Domain.Entities.Employee>(request);
            employee.CafeEmployee = new Domain.Entities.CafeEmployee
            {
                CafeId = request.CafeId,
                StartDate = request.StartDate
            };
            employeeRepository.Create(employee);

            await unitOfWork.Save(cancellationToken);

            return mapper.Map<AddEmployeeCommandResponse>(employee);

        }
    }
}
