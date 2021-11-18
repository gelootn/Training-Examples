using AutoMapper;
using G3L.Examples.NTier.BLL.Models.Company;
using G3L.Examples.NTier.BLL.Models.Employee;
using G3L.Examples.NTier.BLL.Models.Visit;
using G3L.Examples.NTier.DAL.Entities;

namespace G3L.Examples.NTier.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<Employee, EmployeeModel>().ReverseMap();

            CreateMap<Visit, VisitModel>()
                .ForMember(x => x.VisitorName, opt => opt.MapFrom(x => x.Visitor.Name))
                .ForMember(x => x.VisitorEmail, opt => opt.MapFrom(x => x.Visitor.Email))
                .ForMember(x => x.VisitorCompany, opt => opt.MapFrom(x => x.Visitor.Company))
                .ForMember(x => x.Employee, opt => opt.MapFrom(x => x.Employee.Name))
                .ForMember(x => x.Company, opt => opt.MapFrom(x => x.Company.Name));

        }
    }
}