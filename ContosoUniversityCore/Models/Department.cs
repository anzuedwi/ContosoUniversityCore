﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversityCore.Models
{
    public class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        public int DepartmentId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public int? InstructorId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("InstructorId")]
        public Instructor Administrator { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}