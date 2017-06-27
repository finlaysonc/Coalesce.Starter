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

using static Coalesce.TaskListSample.Data.Models.CourseAssignment;

namespace Coalesce.TaskListSample.Web.Models
{
    public partial class CourseAssignmentDtoGen : GeneratedDto<Coalesce.TaskListSample.Data.Models.CourseAssignment, CourseAssignmentDtoGen>
        , IClassDto<Coalesce.TaskListSample.Data.Models.CourseAssignment, CourseAssignmentDtoGen>
    {
        public CourseAssignmentDtoGen() { }

        public Int32? CourseAssignmentID { get; set; }
        public Int32? InstructorID { get; set; }
        public Int32? CourseID { get; set; }
        public InstructorDtoGen Instructor { get; set; }
        public CourseDtoGen Course { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static CourseAssignmentDtoGen Create(Coalesce.TaskListSample.Data.Models.CourseAssignment obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            // Return null of the object is null;
            if (obj == null) return null;

            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for CourseAssignment


            // Applicable excludes for CourseAssignment


            // Applicable roles for CourseAssignment
            if (user != null)
            {
            }



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj))
                return (CourseAssignmentDtoGen)objects[obj];

            var newObject = new CourseAssignmentDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.CourseAssignmentID = obj.CourseAssignmentID;
            newObject.InstructorID = obj.InstructorID;
            newObject.CourseID = obj.CourseID;
            if (tree == null || tree[nameof(newObject.Instructor)] != null)
                newObject.Instructor = InstructorDtoGen.Create(obj.Instructor, user, includes, objects, tree?[nameof(newObject.Instructor)]);

            if (tree == null || tree[nameof(newObject.Course)] != null)
                newObject.Course = CourseDtoGen.Create(obj.Course, user, includes, objects, tree?[nameof(newObject.Course)]);

            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public CourseAssignmentDtoGen CreateInstance(Coalesce.TaskListSample.Data.Models.CourseAssignment obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.TaskListSample.Data.Models.CourseAssignment entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for CourseAssignment


            // Applicable excludes for CourseAssignment


            // Applicable roles for CourseAssignment
            if (user != null)
            {
            }

            entity.InstructorID = (Int32)(InstructorID ?? 0);
            entity.CourseID = (Int32)(CourseID ?? 0);
        }

    }
}
