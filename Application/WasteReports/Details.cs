using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WasteReports
{
    public class Details
    {
        public class Query : IRequest<Result< WasteReportDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<WasteReportDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<WasteReportDto>> Handle(Query request, CancellationToken token)
            {
                var report = await _context.WasteReports.Include(wr => wr.Reporter).FirstOrDefaultAsync(wr => wr.Id == request.Id);
                var res = _mapper.Map<WasteReportDto>(report);
                return Result<WasteReportDto>.Success(res);
            }
        }
    }
}