using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DAL.Models.Company, BLL.Models.Company>();

            CreateMap<DAL.Models.Employee, BLL.Models.Employee>()
                .ForMember(x => x.FullName, cfg => cfg.MapFrom(x => $"{x.LastName} {x.Name}"));
        }
    }
}