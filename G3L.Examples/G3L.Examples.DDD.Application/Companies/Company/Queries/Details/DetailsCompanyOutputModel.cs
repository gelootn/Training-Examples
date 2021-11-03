using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapper.Configuration;
using G3L.Examples.DDD.Application.Companies.Company.Queries.Common;
using G3L.Examples.DDD.Application.Companies.Employee.Queries.Common;

namespace G3L.Examples.DDD.Application.Companies.Company.Queries.Details
{
    public class DetailsCompanyOutputModel : CompanyOutputModel
    {
        public IEnumerable<EmployeeOutputModel> Employees { get; set; }

        public override void Mapping(Profile mapper)
        {
            mapper.CreateMap<Domain.Companies.Models.Company, DetailsCompanyOutputModel>()
                .IncludeBase<Domain.Companies.Models.Company, CompanyOutputModel>()
                .ForMember(x => x.Employees, cfg => cfg
                    .MapFrom(x => x.Employees));
        }
    }
}