using RobotReport.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotReport
{
    public class RobotReportContext : DbContext
    {
        public RobotReportContext(DbContextOptions options) : base(options)
        { }

        //public RobotReportContext(DbContextOptions<RobotReportContext> options)
        //: base(options)
        //{
        //}

        public DbSet<RobotReport.Model.RobotReport> RobotReports { get; set; }
    }
}
