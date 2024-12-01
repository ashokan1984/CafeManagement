namespace CafeManagement.Application.Features.Employee.Create;

public sealed record class AddEmployeeCommandResponse
{
    public Guid ID { get; set; }
}