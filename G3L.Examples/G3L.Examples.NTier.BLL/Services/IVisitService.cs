using System.Collections.Generic;
using System.Threading.Tasks;
using G3L.Examples.NTier.BLL.Models.Visit;

namespace G3L.Examples.NTier.BLL.Services
{
    public interface IVisitService
    {
        Task<IEnumerable<VisitModel>> GetOpenVisits();
        Task<IEnumerable<VisitModel>> GetVisits();
        Task RegisterVisit(StartVisitModel start);
        Task CloseVisit(StopVisitModel stop);
    }
}