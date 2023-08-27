using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteGoals
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public WasteGoal WasteGoal { get; set; }
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

                var existingGoal = await _context.WasteGoals.AnyAsync(wg =>
                    wg.AppUser == user && (
                        wg.EndDate > request.WasteGoal.StartDate && wg.StartDate < request.WasteGoal.EndDate
                    )
                );

                if (existingGoal) return Result<Unit>.Failure("You have overlaping goal for this date period please choose another dates");

                request.WasteGoal.AppUser = user;
                request.WasteGoal.ProgressFood = 0;
                request.WasteGoal.ProgressFuel = 0;
                request.WasteGoal.ProgressWater = 0;
                request.WasteGoal.ProgressPaper = 0;
                request.WasteGoal.ProgressPlastic = 0;

                _context.WasteGoals.Add(request.WasteGoal);

                var res = await _context.SaveChangesAsync() > 0;

                if (res) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to create a goal");
            }
        }
    }
}