using IntelliTect.Coalesce.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using Coalesce.TaskListSample.Web;
using Coalesce.TaskListSample.Data.Models;
using Coalesce.TaskListSample.Data;
using Microsoft.EntityFrameworkCore;

namespace Coalesce.TaskListSample.Web.Controllers
{
    [Authorize]
    public partial class StudentController
        : BaseViewController<Coalesce.TaskListSample.Data.Models.Student, AppDbContext>
    {
        public StudentController() : base()
        {
        }

        [Authorize]
        public ActionResult Cards()
        {
            return IndexImplementation(false, @"~/Views/Generated/Student/Cards.cshtml");
        }

        [Authorize]
        public ActionResult Table()
        {
            return IndexImplementation(false, @"~/Views/Generated/Student/Table.cshtml");
        }


        [Authorize]
        public ActionResult TableEdit()
        {
            return IndexImplementation(true, @"~/Views/Generated/Student/Table.cshtml");
        }

        [Authorize]
        public ActionResult CreateEdit()
        {
            return CreateEditImplementation(@"~/Views/Generated/Student/CreateEdit.cshtml");
        }

        [Authorize]
        public ActionResult EditorHtml(bool simple = false)
        {
            return EditorHtmlImplementation(simple);
        }

        [Authorize]
        public ActionResult Docs()
        {
            return DocsImplementation();
        }
    }
}