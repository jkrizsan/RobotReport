using System;
using System.Linq;
using RobotReport.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RobotReport
{
    /// <summary>
    /// Report Service class
    /// </summary>
    public class ReportService : IReportService
    {

        private readonly RobotReportContext _reportContex;

        private readonly Settings _settings;

        private readonly ILogger _logger;

        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reportContex"></param>
        /// <param name="settings"></param>
        public ReportService(RobotReportContext reportContex,
            Settings settings,
            ILoggerFactory loggerFactory,
            IMapper mapper)
        {
            _settings = settings;
            _reportContex = reportContex;
            _logger = loggerFactory.CreateLogger<ReportService>();
            _mapper = mapper;
        }

        /// <inheritdoc />
        public Model.RobotReport CreateReportData(RobotReportRequest robotReportRequest)
        {
            var commands = robotReportRequest.Commands;
            var report = new Model.RobotReport()
            {
                Commands = commands.Count,
                Timestamp = DateTime.Now,
                Duration = calcDuration(commands),
                Result = commands.Sum(x => x.Steps) + 1
            };

            _logger.LogInformation("Report data is created");

            return report;
        }

        public void SaveReportDataToDB(Model.RobotReport robotReport)
        {
            try
            {
                _reportContex.Add(robotReport);

                _reportContex.SaveChanges();

                _logger.LogInformation("Report data is saved to the Database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while save report data, message: {message}", ex.Message);
                
                throw new Exception("Error happened while tried to save report data to the Database");
            }
        }

        /// <inheritdoc />
        public void ValidateRequestData(RobotReportRequest robotReportRequest)
        {
            validateStartData(robotReportRequest.Start);

            validateCommands(robotReportRequest.Commands);

            _logger.LogInformation("Report data is validated");
        }

        /// <inheritdoc />
        public RobotReportResponse MapReportToResponse(Model.RobotReport robotReport)
            => _mapper.Map<RobotReportResponse>(robotReport);
        
        private void validateCommands(List<Command> commands)
        {
            if (commands.Count > _settings.MaxStepOrCommandLimit)
            {
                throw new ValidationException($"The amount of commands exceed the maximum limits ({_settings.MaxStepOrCommandLimit})!");
            }

            for (int i = 0; i< commands.Count; i++)
            {
                var command = commands[i];

                if (command.Steps > _settings.MaxStepOrCommandLimit)
                {
                    throw new ValidationException($"At the {i + 1}. command, the amount of steps exceed the maximum limits ({_settings.MaxStepOrCommandLimit})!");
                }
                
                if(Enum.TryParse(typeof(Direction), command.Direction, true, out object result) == false)
                {
                    throw new ValidationException($"At the {i + 1}. command, the '{command.Direction}' value is not supported as a Direction!");
                }    
            }
        }

        private void validateStartData(Point start)
        {
            if (start.X < _settings.MinLimitOfPoints || start.Y < _settings.MinLimitOfPoints)
            {
                throw new ValidationException($"The start point values is exceed the minimum limits ({_settings.MinLimitOfPoints})!");
            }

            if (start.X > _settings.MaxLimitOfPoints || start.Y > _settings.MaxLimitOfPoints)
            {
                throw new ValidationException($"The start point values is exceed the maximum limits ({_settings.MaxLimitOfPoints})!");
            }
        }

        private double calcDuration(List<Command> commands)
        {
            double duration = 0;
            double durationSingleStep = 0.001;
            double durationOfSwitchBetweenCommands = 0.003;

            foreach (Command command in commands)
            {
                duration += durationOfSwitchBetweenCommands;
                duration += durationSingleStep * command.Steps;
            }

            return duration;
        }
    }
}
