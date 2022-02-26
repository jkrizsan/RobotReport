using RobotReport.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotReport
{
    public interface IReportService
    {
        /// <summary>
        /// Validate the input data
        /// </summary>
        /// <param name="robotReportRequest"></param>
        void ValidateRequestData(RobotReportRequest robotReportRequest);

        /// <summary>
        /// Create and Save report data to the database
        /// </summary>
        /// <param name="robotReportRequest"></param>
        void CreateAndSaveReportData(RobotReportRequest robotReportRequest);
    }
}
