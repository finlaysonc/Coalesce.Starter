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

using static Coalesce.TaskListSample.Data.Models.Blog;

namespace Coalesce.TaskListSample.Web.Models
{
    public partial class BlogDtoGen : GeneratedDto<Coalesce.TaskListSample.Data.Models.Blog, BlogDtoGen>
        , IClassDto<Coalesce.TaskListSample.Data.Models.Blog, BlogDtoGen>
    {
        public BlogDtoGen() { }

        public Int32? BlogId { get; set; }
        public System.String Name { get; set; }
        public System.String Url { get; set; }
        public Int32? AuthorId { get; set; }
        public AuthorDtoGen Author { get; set; }

        // Create a new version of this object or use it from the lookup.
        public static BlogDtoGen Create(Coalesce.TaskListSample.Data.Models.Blog obj, ClaimsPrincipal user = null, string includes = null,
                                   Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            // Return null of the object is null;
            if (obj == null) return null;

            if (objects == null) objects = new Dictionary<object, object>();

            includes = includes ?? "";

            // Applicable includes for Blog


            // Applicable excludes for Blog


            // Applicable roles for Blog
            if (user != null)
            {
            }



            // See if the object is already created, but only if we aren't restricting by an includes tree.
            // If we do have an IncludeTree, we know the exact structure of our return data, so we don't need to worry about circular refs.
            if (tree == null && objects.ContainsKey(obj))
                return (BlogDtoGen)objects[obj];

            var newObject = new BlogDtoGen();
            if (tree == null) objects.Add(obj, newObject);
            // Fill the properties of the object.
            newObject.BlogId = obj.BlogId;
            newObject.Name = obj.Name;
            newObject.Url = obj.Url;
            newObject.AuthorId = obj.AuthorId;
            if (tree == null || tree[nameof(newObject.Author)] != null)
                newObject.Author = AuthorDtoGen.Create(obj.Author, user, includes, objects, tree?[nameof(newObject.Author)]);

            return newObject;
        }

        // Instance constructor because there is no way to implement a static interface in C#. And generic constructors don't take arguments.
        public BlogDtoGen CreateInstance(Coalesce.TaskListSample.Data.Models.Blog obj, ClaimsPrincipal user = null, string includes = null,
                                Dictionary<object, object> objects = null, IncludeTree tree = null)
        {
            return Create(obj, user, includes, objects, tree);
        }

        // Updates an object from the database to the state handed in by the DTO.
        public void Update(Coalesce.TaskListSample.Data.Models.Blog entity, ClaimsPrincipal user = null, string includes = null)
        {
            includes = includes ?? "";

            if (OnUpdate(entity, user, includes)) return;

            // Applicable includes for Blog


            // Applicable excludes for Blog


            // Applicable roles for Blog
            if (user != null)
            {
            }

            entity.Name = Name;
            entity.Url = Url;
            entity.AuthorId = (Int32)(AuthorId ?? 0);
        }

    }
}
