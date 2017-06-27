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

using static Coalesce.TaskListSample.Data.Models.OfficeAssignment;

namespace Coalesce.TaskListSample.Web.Models
{
    public partial class OfficeAssignmentDtoGen : GeneratedDto<Coalesce.TaskListSample.Data.Models.OfficeAssignment, OfficeAssignmentDtoGen>
        , IClassDto<Coalesce.TaskListSample.Data.Models.OfficeAssignment, OfficeAssignmentDtoGen>
    {
        public OfficeAssignmentDtoGen() { }

        public Int32? InstructorID { get; set; }
        public System.String Location { get; set; }
        public InstructorDtoGen Instructor { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static OfficeAssignmentDtoGen Create(Coalesce.TaskListSample.Data.Models.OfficeAssignment obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            // Return null of the object is null;
            if (obj == null) return null;

            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for OfficeAssignment


            // Applicable excludes for OfficeAssignment


            // Applicable roles for OfficeAssignment
            if (user != null)
            {
            }



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj))
                return (OfficeAssignmentDtoGen)objects[obj];

            var newObject = new OfficeAssignmentDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.InstructorID = obj.InstructorID;
            newObject.Location = obj.Location;
            if (tree == null || tree[nameof(newObject.Instructor)] != null)
                newObject.Instructor = InstructorDtoGen.Create(obj.Instructor, user, includes, objects, tree?[nameof(newObject.Instructor)]);

            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public OfficeAssignmentDtoGen CreateInstance(Coalesce.TaskListSample.Data.Models.OfficeAssignment obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.TaskListSample.Data.Models.OfficeAssignment entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for OfficeAssignment


            // Applicable excludes for OfficeAssignment


            // Applicable roles for OfficeAssignment
            if (user != null)
            {
            }

            entity.Location = Location;
        }

    }
}
