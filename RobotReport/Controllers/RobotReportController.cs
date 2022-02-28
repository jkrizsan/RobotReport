using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        private readonly ILogger _logger;

        public RobotReportController(IReportService reportService, ILoggerFactory _loggerFactory)
        {
            _reportService = reportService;
            _logger = _loggerFactory.CreateLogger<RobotReportController>();
        }

        [HttpPost]
        public IActionResult Post([FromBody] RobotReportRequest requestDto)
        {
            Model.RobotReport robotReport = new Model.RobotReport();

            try
            {
                _reportService.ValidateRequestData(requestDto);
                robotReport = _reportService.CreateReportData(requestDto);
                _reportService.SaveReportDataToDB(robotReport);

                _logger.LogInformation("The Post request is processed successfully.");
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "Validation error, message: {message}", ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error, message: {message}", ex.Message);

                return Problem(ex.Message);
            }

            return Ok(robotReport);
        }

    }
}
