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

using static Coalesce.TaskListSample.Data.Models.ShortBlog;

namespace Coalesce.TaskListSample.Web.Models
{
    public partial class ShortBlogDtoGen : GeneratedDto<Coalesce.TaskListSample.Data.Models.ShortBlog, ShortBlogDtoGen>
        , IClassDto<Coalesce.TaskListSample.Data.Models.ShortBlog, ShortBlogDtoGen>
    {
        public ShortBlogDtoGen() { }

        public Int32? BlogId { get; set; }
        public System.String Url { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static ShortBlogDtoGen Create(Coalesce.TaskListSample.Data.Models.ShortBlog obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            // Return null of the object is null;
            if (obj == null) return null;

            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for ShortBlog


            // Applicable excludes for ShortBlog


            // Applicable roles for ShortBlog
            if (user != null)
            {
            }



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj))
                return (ShortBlogDtoGen)objects[obj];

            var newObject = new ShortBlogDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.BlogId = obj.BlogId;
            newObject.Url = obj.Url;
            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public ShortBlogDtoGen CreateInstance(Coalesce.TaskListSample.Data.Models.ShortBlog obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.TaskListSample.Data.Models.ShortBlog entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for ShortBlog


            // Applicable excludes for ShortBlog


            // Applicable roles for ShortBlog
            if (user != null)
            {
            }

            entity.Url = Url;
        }

    }
}
