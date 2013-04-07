using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcColumnSort.Sample.Models
{
    public class IndexViewModel
    {
        public bool FilterIsEnabled { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}