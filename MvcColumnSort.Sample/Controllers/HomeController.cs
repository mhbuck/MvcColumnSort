using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcColumnSort.Sample.Models;
using MvcColumnSort.Sample.Extensions;

namespace MvcColumnSort.Sample.Controllers
{
    public class HomeController : Controller
    {
        static IEnumerable<Employee> _employees = new List<Employee>()
            {
                new Employee(){ FirstName = "Bob", LastName = "Smith", Age = 30, Gender = "M", YearsOfService = 3},
                new Employee(){ FirstName = "Sally", LastName = "Walters", Age = 23, Gender = "F", YearsOfService = 1},
                new Employee(){ FirstName = "Waylon", LastName = "Smithers", Age = 33, Gender = "M", YearsOfService = 2},
                new Employee(){ FirstName = "Frank", LastName = "Links", Age = 35, Gender = "M", YearsOfService = 5},
                new Employee(){ FirstName = "John", LastName = "Brown", Age = 46, Gender = "M", YearsOfService = 10},
                new Employee(){ FirstName = "Jessica", LastName = "Norton", Age = 23, Gender = "F", YearsOfService = 1},
                new Employee(){ FirstName = "Samantha", LastName = "Millar", Age = 30, Gender = "F", YearsOfService = 3},
            };

        public ActionResult Index(string column, string direction)
        {
            var model = _employees.OrderBy(column, direction.GetSortDirectionFromString());

            return this.View(model);
        }

    }
}
