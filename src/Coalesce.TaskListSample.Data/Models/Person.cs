using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IntelliTect.Coalesce.DataAnnotations;
namespace Coalesce.TaskListSample.Data.Models
{
    public abstract class Person
        {
            [Required]
            [StringLength(50)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Required]
            [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Full Name")]
            [Read]
            public string FullName { get;  set; }
            //{
            //    get
            //    {
            //        return LastName + ", " + FirstMidName;
            //    }
            //}
        }
}
