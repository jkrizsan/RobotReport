using Microsoft.AspNetCore.Mvc;
using RobotReport.Data;

namespace RobotReport.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RobotReportController : Controller
    {
        private readonly IReportService _reportService;
        public RobotReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public string Post([FromBody] RobotReportRequest requestDto)
        {
            try
            {
                _reportService.ValidateRequestData(requestDto);
                _reportService.CreateAndSaveReportData(requestDto);
            }
            catch (System.Exception ex)
            {

                throw;
            }

            return requestDto.ToString();
        }

    }
}
