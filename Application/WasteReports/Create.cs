using Domain;
using MediatR;
using Persistence;

namespace Application.WasteReports
{
    public class Create
    {
        public class Command : IRequest
        {
            public WasteReport WasteReport { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.WasteReports.Add(request.WasteReport);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}