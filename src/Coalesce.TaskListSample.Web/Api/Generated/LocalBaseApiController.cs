using IntelliTect.Coalesce.Controllers;
// Model Namespaces
using Coalesce.TaskListSample.Web;
using Coalesce.TaskListSample.Data.Models;
using Coalesce.TaskListSample.Data;
using IntelliTect.Coalesce.Interfaces;

namespace Coalesce.TaskListSample.Web.Api
{
    // This class allows developers to inject base class behaviors into the inheritance chain
    // This file should not be modified, but another partial class should be created where your custom behavior can be placed.
    public partial class LocalBaseApiController<T, TDto> : BaseApiController<T, TDto, AppDbContext>
        where T : class, new()
        where TDto : class, IClassDto<T, TDto>, new()
    {
    }
}