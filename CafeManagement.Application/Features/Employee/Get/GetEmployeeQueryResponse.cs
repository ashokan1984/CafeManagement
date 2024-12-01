using CafeManagement.Domain.Entities;

namespace CafeManagement.Application.Features.Employee.Get
{
    public record class GetEmployeeQueryResponse
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public GenderEnum Gender { get; set; }
        public string CafeName { get; set; }
        public int NoOfDaysWorked { get; set; }
    }
}
