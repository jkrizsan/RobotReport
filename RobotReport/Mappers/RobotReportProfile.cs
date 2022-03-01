using AutoMapper;
using RobotReport.Data;

namespace RobotReport.Mappers
{
    /// <summary>
    /// RobotReport Profile class
    /// </summary>
    public class RobotReportProfile : Profile
    {
        public RobotReportProfile()
        {
            CreateMap<Model.RobotReport, RobotReportResponse>()
                .ForMember(dest => dest.DatabaseId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
