using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coalesce.TaskListSample.Data;
using IntelliTect.Coalesce.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Coalesce.TaskListSample.Web.Controllers
{
    public class HomeController : BaseControllerWithDb<AppDbContext>
    {
        public bool test(string s)
        {
            return true;
        }

        public HomeController()
        {
        }
        public IActionResult Index()
        {
            //            Db.EnsureAutoHistory();
            //            var y = Db.Enrollments.Where(x => test(x.Course.Title));
            //            Console.WriteLine(Db.Enrollments.Count());
            return View();
        }
    }
}
