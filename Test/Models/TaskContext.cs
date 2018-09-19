using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Test.Models
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Task { get; set; }
    }
}