﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Coalesce.TaskListSample.Data.Models
{
    public class Instructor : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

//        public  ICollection<Course> Courses { get; set; }
    }
}