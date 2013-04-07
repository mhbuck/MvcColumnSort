using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcColumnSort.Sample.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int YearsOfService { get; set; }
        public bool IsActive { get; set; }
    }
}