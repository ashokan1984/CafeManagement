using AutoMapper;
using CafeManagement.Application.Common.Exceptions;
using CafeManagement.Application.Repository;
using MediatR;

namespace CafeManagement.Application.Features.Employee.Update
{
    public class UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<UpdateEmployeeCommandRequest>
    {
        public async Task Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            // Retrieve the existing employee from the repository
            var employee = await employeeRepository.FirstOrDefault(x => x.ID == request.ID) ?? throw new NotFoundException("Employee not found", request.ID);
                        
            // Map the updated values from the request onto the existing employee entity
            mapper.Map(request, employee);
            employee.CafeEmployee = new Domain.Entities.CafeEmployee
            {
                CafeId = request.CafeId,
                StartDate = request.StartDate
            };
            //employee.CafeEmployee.CafeId = request.CafeId;
            //employee.CafeEmployee.StartDate = request.StartDate;

            // Perform the update in the repository
            employeeRepository.Update(employee);

            // Save changes via UnitOfWork
            await unitOfWork.Save(cancellationToken);
        }
    }
}
