using AutoMapper;

namespace CafeManagement.Application.Features.Employee.Get
{
    public class GetEmployeeQueryMapper : Profile
    {
        public GetEmployeeQueryMapper()
        {
            CreateMap<Domain.Entities.Employee, GetEmployeeQueryResponse>()
                .ForMember(member => member.NoOfDaysWorked,
                        from => from.MapFrom(u => DateTime.UtcNow.Subtract(u.CafeEmployee.StartDate).Days))
                .ForMember(member => member.CafeName,
                        from => from.MapFrom(u => u.Cafe.Name));
        }
    }
}
