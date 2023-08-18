using Application.WasteReports;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class WasteReportController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<WasteReport>>> GetWasteReports()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WasteReport>> GetWasteReport(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateWasteReport(WasteReport wasteReport)
        {
            return Ok(await Mediator.Send(new Create.Command { WasteReport = wasteReport }));
        }

        [HttpPut]
        public async Task<IActionResult> EditWasteReport(WasteReport wasteReport)
        {
            return Ok(await Mediator.Send(new Edit.Command { WasteReport = wasteReport }));
        }
    }
}