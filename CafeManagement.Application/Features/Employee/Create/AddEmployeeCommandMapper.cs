using AutoMapper;

namespace CafeManagement.Application.Features.Employee.Create
{
    public class AddEmployeeCommandMapper : Profile
    {
        public AddEmployeeCommandMapper()
        {

            CreateMap<AddEmployeeCommandRequest, Domain.Entities.Employee>();

            CreateMap<Domain.Entities.Employee, AddEmployeeCommandResponse>();
        } 
    }
}
