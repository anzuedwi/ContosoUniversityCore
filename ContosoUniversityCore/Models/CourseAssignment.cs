using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversityCore.Models
{
    public class CourseAssignment
    {
        public int InstructorId { get; set; }

        public int CourseId { get; set; }

        [ForeignKey("InstructorId")]
        public Instructor Instructor { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}