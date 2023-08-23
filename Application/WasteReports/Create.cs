using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteReports
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public WasteReport WasteReport { get; set; }
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
                var sameDateReport = await _context.WasteReports
                    .FirstOrDefaultAsync(wr => wr.Date.Date == request.WasteReport.Date.Date
                        && wr.Reporter.UserName == _userAccessor.GetUserName());
                request.WasteReport.Reporter = user;

                if (sameDateReport != null)
                {
                    sameDateReport.Plastic += request.WasteReport.Plastic;
                    sameDateReport.Paper += request.WasteReport.Paper;
                    sameDateReport.Water += request.WasteReport.Water;
                    sameDateReport.Food += request.WasteReport.Food;
                    sameDateReport.Fuel += request.WasteReport.Fuel;
                }
                else
                {
                    _context.WasteReports.Add(request.WasteReport);
                }

                var res = await _context.SaveChangesAsync(cancellationToken) > 0;


                if (res) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to create a report");
            }
        }
    }
}