using System;

namespace RobotReport.Model
{
    /// <summary>
    /// Romot Report Model Class
    /// </summary>
    public class RobotReport
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp  { get; set; }

        /// <summary>
        /// Number of the commands
        /// </summary>
        public int Commands { get; set; }

        /// <summary>
        /// Number of Unique Places Cleaned,
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// Duration of the Execution
        /// </summary>
        public double Duration { get; set; }
    }
}
