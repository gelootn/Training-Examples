using System.Threading.Tasks;
using G3L.Examples.NTier.BLL.Models.Visit;
using G3L.Examples.NTier.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace G3L.Examples.NTier.API.Controllers
{
    [Route("api/[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _service;

        public VisitController(IVisitService service )
        {
            _service = service;
        }

        [HttpGet("open")]
        public async Task<ActionResult<VisitModel>> OpenVisits()
        {
            var result = await _service.GetOpenVisits();
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<ActionResult<VisitModel>> Visits()
        {
            var result = await _service.GetVisits();
            return Ok(result);
        }
        
        
        [HttpPost("signin")]
        public async Task<IActionResult> RegisterVisit(StartVisitModel startVisit)
        {
            await _service.RegisterVisit(startVisit);
            return Ok();
        }
        
        [HttpPost("signout")]
        public async Task<IActionResult> StopVisit(StopVisitModel stopVisit)
        {
            await _service.CloseVisit(stopVisit);
            return Ok();
        }
        
        
    }
}