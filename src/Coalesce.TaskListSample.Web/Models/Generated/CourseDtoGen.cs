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

using static Coalesce.TaskListSample.Data.Models.Course;

namespace Coalesce.TaskListSample.Web.Models
{
    public partial class CourseDtoGen : GeneratedDto<Coalesce.TaskListSample.Data.Models.Course, CourseDtoGen>
        , IClassDto<Coalesce.TaskListSample.Data.Models.Course, CourseDtoGen>
    {
        public CourseDtoGen() { }

        public Int32? CourseId { get; set; }
        public System.String Title { get; set; }
        public Int32? Credits { get; set; }
        public ICollection<InstructorDtoGen> Instructors { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static CourseDtoGen Create(Coalesce.TaskListSample.Data.Models.Course obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            // Return null of the object is null;
            if (obj == null) return null;

            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for Course


            // Applicable excludes for Course


            // Applicable roles for Course
            if (user != null)
            {
            }



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj))
                return (CourseDtoGen)objects[obj];

            var newObject = new CourseDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.CourseId = obj.CourseId;
            newObject.Title = obj.Title;
            newObject.Credits = obj.Credits;
            var propValInstructors = obj.Instructors;
            if (propValInstructors != null && (tree == null || tree[nameof(newObject.Instructors)] != null))
            {
                newObject.Instructors = propValInstructors.OrderBy("InstructorId ASC").Select(f => InstructorDtoGen.Create(f, user, includes, objects, tree?[nameof(newObject.Instructors)])).ToList();
            }
            else if (propValInstructors == null && tree?[nameof(newObject.Instructors)] != null)
            {
                newObject.Instructors = new InstructorDtoGen[0];
            }

            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public CourseDtoGen CreateInstance(Coalesce.TaskListSample.Data.Models.Course obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.TaskListSample.Data.Models.Course entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for Course


            // Applicable excludes for Course


            // Applicable roles for Course
            if (user != null)
            {
            }

            entity.Title = Title;
            entity.Credits = (Int32)(Credits ?? 0);
        }

    }
}
