using IntelliTect.Coalesce.Interfaces;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.Helpers.IncludeTree;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Security.Claims;
using Coalesce.TaskListSample.Web.Models;
using Coalesce.TaskListSample.Data.Models;
using Coalesce.TaskListSample.Data;

using static Coalesce.TaskListSample.Data.Models.Department;

namespace Coalesce.TaskListSample.Web.Models
{
    public partial class DepartmentDtoGen : GeneratedDto<Coalesce.TaskListSample.Data.Models.Department, DepartmentDtoGen>
        , IClassDto<Coalesce.TaskListSample.Data.Models.Department, DepartmentDtoGen>
    {
        public DepartmentDtoGen() { }

        public Int32? DepartmentID { get; set; }
        public System.String Name { get; set; }
        public Decimal? Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public System.Nullable<System.Int32> InstructorID { get; set; }
        public System.Byte[] RowVersion { get; set; }
        public InstructorDtoGen Administrator { get; set; }
        public ICollection<CourseDtoGen> Courses { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static DepartmentDtoGen Create(Coalesce.TaskListSample.Data.Models.Department obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            // Return null of the object is null;
            if (obj == null) return null;

            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for Department


            // Applicable excludes for Department


            // Applicable roles for Department
            if (user != null)
            {
            }



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj))
                return (DepartmentDtoGen)objects[obj];

            var newObject = new DepartmentDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.DepartmentID = obj.DepartmentID;
            newObject.Name = obj.Name;
            newObject.Budget = obj.Budget;
            newObject.StartDate = obj.StartDate;
            newObject.InstructorID = obj.InstructorID;
            newObject.RowVersion = obj.RowVersion;
            if (tree == null || tree[nameof(newObject.Administrator)] != null)
                newObject.Administrator = InstructorDtoGen.Create(obj.Administrator, user, includes, objects, tree?[nameof(newObject.Administrator)]);

            var propValCourses = obj.Courses;
            if (propValCourses != null && (tree == null || tree[nameof(newObject.Courses)] != null))
            {
                newObject.Courses = propValCourses.OrderBy("CourseID ASC").Select(f => CourseDtoGen.Create(f, user, includes, objects, tree?[nameof(newObject.Courses)])).ToList();
            }
            else if (propValCourses == null && tree?[nameof(newObject.Courses)] != null)
            {
                newObject.Courses = new CourseDtoGen[0];
            }

            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public DepartmentDtoGen CreateInstance(Coalesce.TaskListSample.Data.Models.Department obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.TaskListSample.Data.Models.Department entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for Department


            // Applicable excludes for Department


            // Applicable roles for Department
            if (user != null)
            {
            }

            entity.Name = Name;
            entity.Budget = (Decimal)(Budget ?? 0);
            entity.StartDate = (DateTime)(StartDate ?? DateTime.Today);
            entity.InstructorID = InstructorID;
            entity.RowVersion = RowVersion;
        }

    }
}
