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
        /// 
        /// </summary>
        /// <param name="robotReportRequest"></param>
        /// <returns>RobotReport</returns>
        Model.RobotReport CreateAndSaveReportData(RobotReportRequest robotReportRequest);
    }
}
