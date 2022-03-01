using System;

namespace RobotReport.Exceptions
{
    /// <summary>
    /// Exception that indicate by the database errors
    /// </summary>
    public class SavedatabaseException: Exception
    {
        public SavedatabaseException(string message)
            : base(message)
        {
        }
    }
}
