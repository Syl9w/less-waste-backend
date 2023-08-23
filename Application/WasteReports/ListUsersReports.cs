using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteReports
{
    public class ListUsersReports
    {
        public class Query : IRequest<Result<List<WasteReportDto>>>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<WasteReportDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<Result<List<WasteReportDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var wasteReports = await _context.WasteReports
                    .Include(wr => wr.Reporter)
                    .Where(wr => wr.Reporter.UserName == request.UserName)
                    .ToListAsync();

                return Result<List<WasteReportDto>>.Success(_mapper.Map<List<WasteReportDto>>(wasteReports));
            }
        }
    }
}