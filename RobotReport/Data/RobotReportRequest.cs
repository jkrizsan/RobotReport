using System.Collections.Generic;

namespace RobotReport.Data
{
    /// <summary>
    /// Dto class for the report request
    /// </summary>
    public class RobotReportRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RobotReportRequest()
        {
            Commands = new List<Command>();
        }

        /// <summary>
        /// Position of the start point
        /// </summary>
        public Point Start { get; set; }

        /// <summary>
        /// Collection of the commands
        /// </summary>
        public List<Command> Commands { get; set; }
    }
}
