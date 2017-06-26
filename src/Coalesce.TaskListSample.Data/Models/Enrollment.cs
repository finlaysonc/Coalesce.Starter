using System.ComponentModel.DataAnnotations;

namespace Coalesce.TaskListSample.Data.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    //public class CourseInstructor
    //{
    //    public int CourseInstructorID { get; set; }
    //    public int InstructorID { get; set; }
    //    public int CourseID { get; set; }

    //    public  Course Course { get; set; }
    //    public  Instructor Instructor { get; set; }
    //}


    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public  Course Course { get; set; }
        public  Student Student { get; set; }
    }
}
