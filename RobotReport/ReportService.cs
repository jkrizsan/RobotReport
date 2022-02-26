using RobotReport.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RobotReport
{
    /// <summary>
    /// Report Service
    /// </summary>
    public class ReportService : IReportService
    {
        private RobotReportContext _reportContex;

        public ReportService(RobotReportContext reportContex)
        {
            _reportContex = reportContex;
        }

        /// <inheritdoc />
        public Model.RobotReport CreateAndSaveReportData(RobotReportRequest robotReportRequest)
        {
            var commands = robotReportRequest.Commands;
            var report = new Model.RobotReport()
            {
                Commands = commands.Count,
                Timestamp = DateTime.Now,
                Duration = calcDuration(commands),
                Result = commands.Sum(x => x.Steps) + 1
            };

            //_reportContex.Add(report);

            //_reportContex.SaveChanges();

            return report;
        }

        /// <inheritdoc />
        public void ValidateRequestData(RobotReportRequest robotReportRequest)
        {

            validateStartData(robotReportRequest.Start);
            validateCommands(robotReportRequest.Commands);
        }

        private void validateCommands(List<Command> commands)
        {
            if (commands.Any(x => x.Steps > 100000) || commands.Count > 100000)
            {
                throw new ValidationException("Too much steps within a command or too much command!");
            }
        }

        private void validateStartData(Point start)
        {
            int minLimit = -100000;
            if (start.X < minLimit || start.Y < minLimit)
            {
                throw new ValidationException("Some start point values is too low!");
            }

            int maxLimit = 100000;
            if (start.X > maxLimit || start.Y > maxLimit)
            {
                throw new ValidationException("Some start point values is too high!");
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
