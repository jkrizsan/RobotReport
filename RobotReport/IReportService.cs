using RobotReport.Data;

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
        /// Create Report Data
        /// </summary>
        /// <param name="robotReportRequest"></param>
        /// <returns>RobotReport</returns>
        Model.RobotReport CreateReportData(RobotReportRequest robotReportRequest);

        /// <summary>
        /// Save the Report Data to the Database
        /// </summary>
        /// <param name="robotReport"></param>
        void SaveReportDataToDB(Model.RobotReport robotReport);
    }
}
