using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.DBInit
{
    public class EFCoreDemoDbContext : BaseDbContext
    {
        public EFCoreDemoDbContext(bool isLogging = false, bool isNoLock = false) : base("EFCoreDemoDB", isLogging, isNoLock)
        {

        }

        public DbSet<Student> Student { get; set; }
    }
}
