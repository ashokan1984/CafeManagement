using CafeManagement.Domain.Entities;
using MediatR;

namespace CafeManagement.Application.Features.Employee.Update;

public record class UpdateEmployeeCommandRequest(Guid ID, Guid CafeId, string Name, string EmailAddress, 
    string PhoneNumber, GenderEnum Gender, DateTime StartDate) : IRequest;
