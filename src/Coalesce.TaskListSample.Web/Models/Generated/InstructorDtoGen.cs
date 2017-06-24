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

using static Coalesce.TaskListSample.Data.Models.Instructor;

namespace Coalesce.TaskListSample.Web.Models
{
    public partial class InstructorDtoGen : GeneratedDto<Coalesce.TaskListSample.Data.Models.Instructor, InstructorDtoGen>
        , IClassDto<Coalesce.TaskListSample.Data.Models.Instructor, InstructorDtoGen>
    {
        public InstructorDtoGen() { }

        public Int32? InstructorId { get; set; }
        public DateTime? HireDate { get; set; }
        public System.String LastName { get; set; }
        public System.String FirstName { get; set; }
        public System.String FullName { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static InstructorDtoGen Create(Coalesce.TaskListSample.Data.Models.Instructor obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            // Return null of the object is null;
            if (obj == null) return null;

            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for Instructor


            // Applicable excludes for Instructor


            // Applicable roles for Instructor
            if (user != null)
            {
            }



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj))
                return (InstructorDtoGen)objects[obj];

            var newObject = new InstructorDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.InstructorId = obj.InstructorId;
            newObject.HireDate = obj.HireDate;
            newObject.LastName = obj.LastName;
            newObject.FirstName = obj.FirstName;
            newObject.FullName = obj.FullName;
            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public InstructorDtoGen CreateInstance(Coalesce.TaskListSample.Data.Models.Instructor obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.TaskListSample.Data.Models.Instructor entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for Instructor


            // Applicable excludes for Instructor


            // Applicable roles for Instructor
            if (user != null)
            {
            }

            entity.HireDate = (DateTime)(HireDate ?? DateTime.Today);
            entity.LastName = LastName;
            entity.FirstName = FirstName;
        }

    }
}
