using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IntelliTect.Coalesce.DataAnnotations;
namespace Coalesce.TaskListSample.Data.Models
{
    public class Student : Person
    {
        [Key]
        public int StudentId { get; set; }

//        [DataType(DataType.Date)]
        [DateType(DateTypeAttribute.DateTypes.DateOnly)]
  //      [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public  ICollection<Enrollment> Enrollments { get; set; }
    }
}
