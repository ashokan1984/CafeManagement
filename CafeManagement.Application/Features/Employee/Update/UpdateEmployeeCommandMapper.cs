using AutoMapper;
using CafeManagement.Application.Features.Employee.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Features.Employee.Update
{
    public class UpdateEmployeeCommandMapper : Profile
    {
        public UpdateEmployeeCommandMapper()
        {
            CreateMap<UpdateEmployeeCommandRequest, Domain.Entities.Employee>();
        }
    }
}
