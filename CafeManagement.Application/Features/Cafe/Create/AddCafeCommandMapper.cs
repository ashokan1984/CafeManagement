using AutoMapper;

namespace CafeManagement.Application.Features.Cafe.Create
{
    public class AddCafeCommandMapper : Profile
    {
        public AddCafeCommandMapper()
        {
            CreateMap<AddCafeCommandRequest, Domain.Entities.Cafe>().
               ForMember(member => member.Logo, map => map.MapFrom(x => x.Logo != null ? x.Logo.Bytes : null))
               .ForMember(member => member.ContentType, map => map.MapFrom(x => x.Logo != null ? x.Logo.ContentType : null));

            CreateMap<Domain.Entities.Cafe, AddCafeCommandResponse>();
        }
    }
}
