using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteGoals
{
    public class Update
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdateGoalDto UpdateGoal { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == _userAccessor.GetUserName());

                if (user == null) return null;

                var goal = await _context.WasteGoals
                    .FirstOrDefaultAsync(wg => wg.AppUser == user && DateTime.Now > wg.StartDate && DateTime.Now < wg.EndDate);

                if (goal == null) return null;

                goal.ProgressFood += request.UpdateGoal.ProgressFood;
                goal.ProgressFuel += request.UpdateGoal.ProgressFuel;
                goal.ProgressPaper += request.UpdateGoal.ProgressPaper;
                goal.ProgressPlastic += request.UpdateGoal.ProgressPaper;
                goal.ProgressWater += request.UpdateGoal.ProgressWater;

                var res = await _context.SaveChangesAsync() > 0;

                if (res) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to update your progress");
            }
        }
    }
}