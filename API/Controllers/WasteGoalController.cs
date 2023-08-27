using Application.WasteGoals;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class WasteGoalController : BaseApiController
    {
        [HttpGet("{username}")]
        public async Task<ActionResult<List<WasteGoal>>> GetUserGoals(string username)
        {
            return HandleResult(await Mediator.Send(new Details.Query { UserName = username }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserGoal(WasteGoal wasteGoal)
        {
            return HandleResult(await Mediator.Send(new Create.Command { WasteGoal = wasteGoal }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWasteGoal(UpdateGoalDto updateGoal)
        {
            return HandleResult(await Mediator.Send(new Update.Command { UpdateGoal = updateGoal }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{Id=id}));
        }
    }
}