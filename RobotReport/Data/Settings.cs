namespace RobotReport.Data
{
    /// <summary>
    /// Dto class for Application Settings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Maximum limit for amount of steps or commands
        /// </summary>
        public int MaxStepOrCommandLimit { get; set; }

        /// <summary>
        /// Minimum limit of the Points
        /// </summary>
        public int MinLimitOfPoints { get; set; }

        /// <summary>
        /// Maximum limit of the Points
        /// </summary>
        public int MaxLimitOfPoints { get; set; }
    }
}
