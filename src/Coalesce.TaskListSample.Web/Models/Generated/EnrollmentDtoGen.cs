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

using static Coalesce.TaskListSample.Data.Models.Enrollment;

namespace Coalesce.TaskListSample.Web.Models
{
    public partial class EnrollmentDtoGen : GeneratedDto<Coalesce.TaskListSample.Data.Models.Enrollment, EnrollmentDtoGen>
        , IClassDto<Coalesce.TaskListSample.Data.Models.Enrollment, EnrollmentDtoGen>
    {
        public EnrollmentDtoGen() { }

        public Int32? EnrollmentId { get; set; }
        public Int32? CourseId { get; set; }
        public Int32? StudentId { get; set; }
        public System.Nullable<Coalesce.TaskListSample.Data.Models.Grade> Grade { get; set; }
        public CourseDtoGen Course { get; set; }
        public StudentDtoGen Student { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static EnrollmentDtoGen Create(Coalesce.TaskListSample.Data.Models.Enrollment obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            // Return null of the object is null;
            if (obj == null) return null;

            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for Enrollment


            // Applicable excludes for Enrollment


            // Applicable roles for Enrollment
            if (user != null)
            {
            }



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj))
                return (EnrollmentDtoGen)objects[obj];

            var newObject = new EnrollmentDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.EnrollmentId = obj.EnrollmentId;
            newObject.CourseId = obj.CourseId;
            newObject.StudentId = obj.StudentId;
            newObject.Grade = obj.Grade;
            if (tree == null || tree[nameof(newObject.Course)] != null)
                newObject.Course = CourseDtoGen.Create(obj.Course, user, includes, objects, tree?[nameof(newObject.Course)]);

            if (tree == null || tree[nameof(newObject.Student)] != null)
                newObject.Student = StudentDtoGen.Create(obj.Student, user, includes, objects, tree?[nameof(newObject.Student)]);

            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public EnrollmentDtoGen CreateInstance(Coalesce.TaskListSample.Data.Models.Enrollment obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.TaskListSample.Data.Models.Enrollment entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for Enrollment


            // Applicable excludes for Enrollment


            // Applicable roles for Enrollment
            if (user != null)
            {
            }

            entity.CourseId = (Int32)(CourseId ?? 0);
            entity.StudentId = (Int32)(StudentId ?? 0);
            entity.Grade = Grade;
        }

    }
}
