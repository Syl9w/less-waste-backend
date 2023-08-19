using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.WasteReports
{
    public class List
    {
        public class Query : IRequest<List<WasteReportDto>>
        {

        }

        public class Handler : IRequestHandler<Query, List<WasteReportDto>>
        {
            private readonly DataContext _context;
        private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
            _mapper = mapper;
                _context = context;
            }

            public async Task<List<WasteReportDto>> Handle(Query request, CancellationToken token)
            {
                var wasteReports = await _context.WasteReports.Include(wr => wr.Reporter).ToListAsync();

                return _mapper.Map<List<WasteReportDto>>(wasteReports);
            }
        }
    }
}