using Application.WasteReports;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<WasteReport, WasteReport>();
            CreateMap<WasteReport, WasteReportDto>()
               .ForMember(dest => dest.Reporter,
                opt => opt.MapFrom(src => new ReporterDto
                {
                    UserName = src.Reporter.UserName,
                    DisplayName = src.Reporter.DisplayName,
                    Age = src.Reporter.Age
                }));
            CreateMap<AppUser, ReporterDto>();
        }
    }
}