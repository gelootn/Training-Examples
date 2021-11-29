using System.Threading.Tasks;
using G3L.Examples.NTier.BLL.Models.Visit;

namespace G3L.Examples.NTier.BLL.Services;

public interface IVisitService
{
    Task<Response<VisitModel>> GetOpenVisits();
    Task<Response<VisitModel>> GetVisits();
    Task RegisterVisit(StartVisitModel start);
    Task CloseVisit(StopVisitModel stop);
}
