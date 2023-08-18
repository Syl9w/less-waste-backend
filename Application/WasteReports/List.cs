using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteReports
{
    public class List
    {
        public class Query : IRequest<List<WasteReport>>
        {

        }

        public class Handler : IRequestHandler<Query, List<WasteReport>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<WasteReport>> Handle(Query request, CancellationToken token)
            {
                return await _context.WasteReports.ToListAsync();
            }
        }
    }
}