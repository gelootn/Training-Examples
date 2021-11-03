using System.Collections.Generic;
using AutoMapper;
using G3L.Examples.DDD.Application.Common.Interfaces;
using G3L.Examples.DDD.Application.Companies.Employee.Queries.Common;

namespace G3L.Examples.DDD.Application.Companies.Company.Queries.Common
{
    public class CompanyOutputModel : IMapFrom<Domain.Companies.Models.Company>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual void Mapping(Profile mapper)
        {
            mapper.CreateMap<Domain.Companies.Models.Company, CompanyOutputModel>();
        }
    }
}