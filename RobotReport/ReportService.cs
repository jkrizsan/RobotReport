using RobotReport.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public void CreateAndSaveReportData(RobotReportRequest robotReportRequest)
        {
            _reportContex.Add(new Model.RobotReport()
            {
                Commands=10,
                Timestamp=DateTime.Now,
                Duration = 10,
                Result = 4
            });

            _reportContex.SaveChanges();
        }

        /// <inheritdoc />
        public void ValidateRequestData(RobotReportRequest robotReportRequest)
        {

            validateStartData(robotReportRequest.Start);
            validateCommands(robotReportRequest.Commands);
        }

        private void validateCommands(List<Command> commands)
        {
          //  throw new NotImplementedException();
        }

        private void validateStartData(Point start)
        {
            int minLimit = - 100000;
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
    }
}
