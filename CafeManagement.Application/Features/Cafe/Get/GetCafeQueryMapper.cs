using AutoMapper;

namespace CafeManagement.Application.Features.Cafe.Get;

public class GetCafeQueryMapper : Profile
{
    public GetCafeQueryMapper()
    {
        CreateMap<Domain.Entities.Cafe, GetCafeQueryResponse>()
            .ForMember(member => member.LogoDetail, map => map.MapFrom(x => new Image(x.Logo, x.ContentType)))
            .ForMember(member => member.EmployeeCount, map => map.MapFrom(y => y.Employees != null ? y.Employees.Count() : 0));
    }
}
