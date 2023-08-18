using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteReports
{
    public class Edit
    {
        public class Command : IRequest
        {
            public WasteReport WasteReport { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var wasteReport = await _context.WasteReports.FirstOrDefaultAsync(wr => wr.Id == request.WasteReport.Id);
                _mapper.Map<WasteReport>(wasteReport);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}