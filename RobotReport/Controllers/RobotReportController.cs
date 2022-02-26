using Microsoft.AspNetCore.Mvc;
using RobotReport.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace RobotReport.Controllers
{
    [ApiController]
    [Route("tibber-developer-test")]
    public class RobotReportController : Controller
    {
        private readonly IReportService _reportService;
        public RobotReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RobotReportRequest requestDto)
        {
            Model.RobotReport robotReport = new Model.RobotReport();

            try
            {
                _reportService.ValidateRequestData(requestDto);
                robotReport = _reportService.CreateAndSaveReportData(requestDto);
            }
            catch (ValidationException ex)
            {
                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }

            return Ok(robotReport);
        }

    }
}
