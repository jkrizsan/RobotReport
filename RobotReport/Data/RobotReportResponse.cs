using System;

namespace RobotReport.Data
{
    /// <summary>
    /// Dto class for Robot Report response
    /// </summary>
    public class RobotReportResponse
    {
        /// <summary>
        /// Database Id
        /// </summary>
        public int DatabaseId { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Number of the commands
        /// </summary>
        public int Commands { get; set; }

        /// <summary>
        /// Number of Unique Cleaned Places,
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// Duration of the Execution
        /// </summary>
        public double Duration { get; set; }
    }
}
