using IntelliTect.Coalesce.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using Coalesce.TaskListSample.Web;
using Coalesce.TaskListSample.Data.Models;
using Coalesce.TaskListSample.Data;

namespace Coalesce.TaskListSample.Web.Controllers
{
    [Authorize]
    public partial class CourseAssignmentController
        : BaseViewController<Coalesce.TaskListSample.Data.Models.CourseAssignment, AppDbContext>
    {
        public CourseAssignmentController() : base() { }

        [Authorize]
        public ActionResult Cards()
        {
            return IndexImplementation(false, @"~/Views/Generated/CourseAssignment/Cards.cshtml");
        }

        [Authorize]
        public ActionResult Table()
        {
            return IndexImplementation(false, @"~/Views/Generated/CourseAssignment/Table.cshtml");
        }


        [Authorize]
        public ActionResult TableEdit()
        {
            return IndexImplementation(true, @"~/Views/Generated/CourseAssignment/Table.cshtml");
        }

        [Authorize]
        public ActionResult CreateEdit()
        {
            return CreateEditImplementation(@"~/Views/Generated/CourseAssignment/CreateEdit.cshtml");
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