using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteGoals
{
    public class Details
    {
        public class Query : IRequest<Result<List<WasteGoalDto>>>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<WasteGoalDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<WasteGoalDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);

                if (user == null) return null;

                var goals = await _context.WasteGoals.Where(wg => wg.AppUserId == user.Id).ToListAsync();

                return Result<List<WasteGoalDto>>.Success(_mapper.Map<List<WasteGoalDto>>( goals));
            }
        }
    }
}