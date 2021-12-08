using AutoMapper;
using MicroServices.CompanyService.BLL.Models;
using MicroServices.CompanyService.DAL.Repositories.Contracts;

namespace MicroServices.CompanyService.BLL.Queries.GetCompanies
{
    internal class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, ICollection<Company>>
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public GetCompaniesQueryHandler(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<Company>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();
            var mapped = _mapper.Map<ICollection<Company>>(result);
            return mapped;
        }
    }
}
