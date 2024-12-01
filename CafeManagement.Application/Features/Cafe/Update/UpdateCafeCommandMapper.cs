using AutoMapper;
using CafeManagement.Application.Features.Cafe.Create;

namespace CafeManagement.Application.Features.Cafe.Update
{
    public class UpdateCafeCommandMapper : Profile
    {
        public UpdateCafeCommandMapper()
        {
            CreateMap<UpdateCafeCommandRequest, Domain.Entities.Cafe>().
              ForMember(member => member.Logo, map => map.MapFrom(x => x.Logo != null ? x.Logo.Bytes : null))
              .ForMember(member => member.ContentType, map => map.MapFrom(x => x.Logo != null ? x.Logo.ContentType : null));
        }
    }
}
