using Application.WasteReports;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class WasteReportController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<WasteReportDto>>> GetWasteReports()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("reports/{username}")]
        public async Task<ActionResult<List<WasteReportDto>>> GetUsersWasteReports(string username)
        {
            return HandleResult(await Mediator.Send(new ListUsersReports.Query { UserName = username }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WasteReportDto>> GetWasteReport(Guid id)
        {
            return  HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWasteReport(WasteReport wasteReport)
        {
            return HandleResult(await Mediator.Send(new Create.Command { WasteReport = wasteReport }));
        }
    }
}