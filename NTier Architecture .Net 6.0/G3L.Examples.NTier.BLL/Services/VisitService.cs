using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using G3L.Examples.NTier.BLL.Models.Visit;
using Microsoft.EntityFrameworkCore;

namespace G3L.Examples.NTier.BLL.Services;

public class VisitService : IVisitService
{
    private readonly IAsyncGenericRepository<Visit> _visitRepo;
    private readonly IAsyncGenericRepository<Company> _companyRepo;
    private readonly IAsyncGenericRepository<Employee> _employeeRepo;
    private readonly IAsyncGenericRepository<Visitor> _visitorRepo;
    private readonly IMapper _mapper;

    public VisitService(
        IAsyncGenericRepository<Visit> visitRepo,
        IAsyncGenericRepository<Company> companyRepo,
        IAsyncGenericRepository<Employee> employeeRepo,
        IAsyncGenericRepository<Visitor> visitorRepo,
        IMapper mapper)
    {
        _visitRepo = visitRepo;
        _companyRepo = companyRepo;
        _employeeRepo = employeeRepo;
        _visitorRepo = visitorRepo;
        _mapper = mapper;
    }

    public async Task<Response<VisitModel>> GetOpenVisits()
    {
        var result = await _visitRepo.GetAsync(
            x => x.Stop == null,
            q => q.Include(x => x.Company)
                    .Include(x => x.Employee)
                    .Include(x => x.Visitor));
        var mapped = result.Select(x => _mapper.Map<VisitModel>(x)).ToList();
        return new Response<VisitModel>(mapped);
    }

    public async Task<Response<VisitModel>> GetVisits()
    {
        var result = await _visitRepo.GetAsync(
            x => x.Stop != null,
            q => q.Include(x => x.Company)
                .Include(x => x.Employee)
                .Include(x => x.Visitor));
        var mapped = result.Select(x => _mapper.Map<VisitModel>(x)).ToList();
        return new Response<VisitModel>(mapped);
    }

    public async Task RegisterVisit(StartVisitModel start)
    {
        var company = await _companyRepo.FirstOrDefaultAsync(x => x.Id == start.CompanyId);
        var employee = await _employeeRepo.FirstOrDefaultAsync(x => x.Id == start.EmployeeId && x.CompanyId == start.CompanyId);

        var visitor = await _visitorRepo.FirstOrDefaultAsync(x => x.Email == start.VisitorEmail);

        if (visitor == null)
            visitor = new Visitor
            {
                Name = start.VisitorName,
                Email = start.VisitorEmail,
                Company = start.VisitorCompany
            };

        var visit = new Visit();

        visit.Start = start.Start;
        visit.Company = company;
        visit.Employee = employee;
        visit.Visitor = visitor;

        await _visitRepo.AddOrUpdateAsync(visit);
        await _visitorRepo.SaveChangesAsync();
    }

    public async Task CloseVisit(StopVisitModel stop)
    {
        var visit = await _visitRepo.FirstOrDefaultAsync(x => x.Visitor.Email == stop.VisitorEmail && x.Stop == null);
        if (visit != null)
        {
            visit.Stop = stop.Stop;
        }

        await _visitRepo.AddOrUpdateAsync(visit);
        await _visitorRepo.SaveChangesAsync();
    }

}
