using System;
using AutoMapper;
using G3L.Examples.DDD.Application.Common.Interfaces;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Queries.Common
{
    public class VisitOutputModel : IMapFrom<Domain.Visiting.Models.Visit>
    {
        public string VisitorName { get; set; }
        public string VisitorEmail { get; set; }
        public string VisitorCompany { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Stop { get; set; }
        public string Employee { get; set; }
        public string Company { get; set; }

        public virtual void Mapping(Profile mapper)
        {
            mapper.CreateMap<Domain.Visiting.Models.Visit, VisitOutputModel>()
                .ForMember(x => x.VisitorName, cfg => cfg
                    .MapFrom(v => v.Visitor.Name))
                .ForMember(x => x.VisitorEmail, cfg => cfg
                    .MapFrom(v => v.Visitor.Email))
                .ForMember(x => x.VisitorCompany, cfg => cfg
                    .MapFrom(v => v.Visitor.CompanyName))
                .ForMember(x => x.Company, cfg => cfg
                    .MapFrom(v => v.Company.Name))
                .ForMember(x => x.Employee, cfg => cfg
                    .MapFrom(v => v.Employee.Name));
        }
    }
}   