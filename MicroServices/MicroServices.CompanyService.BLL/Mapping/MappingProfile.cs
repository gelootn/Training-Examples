using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                .ForMember(x=> x.LastName, cfg => cfg.MapFrom(x => x.LastName))
                .ForMember(x=> x.FirstName, cfg => cfg.MapFrom(x => x.Name));
        }
    }
}