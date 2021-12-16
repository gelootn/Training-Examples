using MicroServices.Common.BLL.Infrastructure.Exceptions;
using MicroServices.CompanyService.BLL.Models;
using MicroServices.CompanyService.DAL.Repositories.Contracts;

namespace MicroServices.CompanyService.BLL.Queries.GetCompany;

internal class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, Company>
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public GetCompanyQueryHandler(ICompanyRepository repository, IMapper mapper )
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Company> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _repository.GetAsync(request.Id);
        if (company == null) throw new ItemNotFoundException(request.Id, typeof(Company));

        return _mapper.Map<Company>(company);
    }
}