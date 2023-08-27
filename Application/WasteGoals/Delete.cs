using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteGoals
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var user = await _context.Users
                    .FirstOrDefaultAsync(u=>u.UserName==_userAccessor.GetUserName());

                if(user==null) return null;

                var goal = await _context.WasteGoals
                    .FirstOrDefaultAsync(wg=>wg.Id==request.Id);

                if(goal==null) return null;

                if(user != goal.AppUser) return null;

                _context.WasteGoals.Remove(goal);

                var res = await _context.SaveChangesAsync()>0;

                if(res) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to update data");
            }
        }
    }
}