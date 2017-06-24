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

using static Coalesce.TaskListSample.Data.Models.Student;

namespace Coalesce.TaskListSample.Web.Models
{
    public partial class StudentDtoGen : GeneratedDto<Coalesce.TaskListSample.Data.Models.Student, StudentDtoGen>
        , IClassDto<Coalesce.TaskListSample.Data.Models.Student, StudentDtoGen>
    {
        public StudentDtoGen() { }

        public Int32? StudentId { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public System.String LastName { get; set; }
        public System.String FirstName { get; set; }
        public System.String FullName { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static StudentDtoGen Create(Coalesce.TaskListSample.Data.Models.Student obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            // Return null of the object is null;
            if (obj == null) return null;

            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for Student


            // Applicable excludes for Student


            // Applicable roles for Student
            if (user != null)
            {
            }



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj))
                return (StudentDtoGen)objects[obj];

            var newObject = new StudentDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.StudentId = obj.StudentId;
            newObject.EnrollmentDate = obj.EnrollmentDate;
            newObject.LastName = obj.LastName;
            newObject.FirstName = obj.FirstName;
            newObject.FullName = obj.FullName;
            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public StudentDtoGen CreateInstance(Coalesce.TaskListSample.Data.Models.Student obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.TaskListSample.Data.Models.Student entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for Student


            // Applicable excludes for Student


            // Applicable roles for Student
            if (user != null)
            {
            }

            entity.EnrollmentDate = (DateTime)(EnrollmentDate ?? DateTime.Today);
            entity.LastName = LastName;
            entity.FirstName = FirstName;
        }

    }
}
