using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversityCore.Models
{
    public enum Grade
    {
        [Display(Name = "Grade A")]
        A,

        [Display(Name = "Grade B")]
        B,

        [Display(Name = "Grade C")]
        C,

        [Display(Name = "Grade D")]
        D,

        [Display(Name = "Grade F")]
        F
    }

    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}