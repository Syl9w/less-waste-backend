using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteReports
{
    public class Details
    {
        public class Query : IRequest<WasteReport>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, WasteReport>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<WasteReport> Handle(Query request, CancellationToken token){
                return await _context.WasteReports.FirstOrDefaultAsync(wr=>wr.Id==request.Id);
            }
        }
    }
}