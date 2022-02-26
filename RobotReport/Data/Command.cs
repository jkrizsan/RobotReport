namespace RobotReport.Data
{
    /// <summary>
    /// Dto class for represent a simple command
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Direction that the command given
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Number of the Steps that have to take to the specified direction
        /// </summary>
        public int Steps { get; set; }
    }
}