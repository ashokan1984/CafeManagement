using CafeManagement.Domain.Entities;
using MediatR;

namespace CafeManagement.Application.Features.Employee.Create;

public sealed record class AddEmployeeCommandRequest(Guid CafeId, string EmployeeId, string Name, string EmailAddress, string PhoneNumber, GenderEnum Gender, DateTime StartDate) : IRequest<AddEmployeeCommandResponse>;
