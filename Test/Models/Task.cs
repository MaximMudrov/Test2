using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public Boolean TaskDone { get; set; }
    }
}