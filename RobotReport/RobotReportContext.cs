using Microsoft.EntityFrameworkCore;

namespace RobotReport
{
    public class RobotReportContext : DbContext
    {
        public RobotReportContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Model.RobotReport> RobotReports { get; set; }
    }
}
