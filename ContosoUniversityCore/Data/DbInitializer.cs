﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversityCore.Models;
using Microsoft.AspNetCore.Identity;

namespace ContosoUniversityCore.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager )
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Abercrombie").PersonId },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Fakhouri").PersonId },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Harui").PersonId },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Kapoor").PersonId }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseId = 1050, Title = "Chemistry",      Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Engineering").DepartmentId
                },
                new Course {CourseId = 4022, Title = "Microeconomics", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Economics").DepartmentId
                },
                new Course {CourseId = 4041, Title = "Macroeconomics", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Economics").DepartmentId
                },
                new Course {CourseId = 1045, Title = "Calculus",       Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Mathematics").DepartmentId
                },
                new Course {CourseId = 3141, Title = "Trigonometry",   Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Mathematics").DepartmentId
                },
                new Course {CourseId = 2021, Title = "Composition",    Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "English").DepartmentId
                },
                new Course {CourseId = 2042, Title = "Literature",     Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "English").DepartmentId
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Fakhouri").PersonId,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Harui").PersonId,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Kapoor").PersonId,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Kapoor").PersonId
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Harui").PersonId
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Microeconomics" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Zheng").PersonId
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Macroeconomics" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Zheng").PersonId
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Calculus" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Fakhouri").PersonId
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Trigonometry" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Harui").PersonId
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Composition" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Abercrombie").PersonId
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Literature" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Abercrombie").PersonId
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Alexander").PersonId,
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Alexander").PersonId,
                    CourseId = courses.Single(c => c.Title == "Microeconomics" ).CourseId,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Alexander").PersonId,
                    CourseId = courses.Single(c => c.Title == "Macroeconomics" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentId = students.Single(s => s.LastName == "Alonso").PersonId,
                    CourseId = courses.Single(c => c.Title == "Calculus" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentId = students.Single(s => s.LastName == "Alonso").PersonId,
                    CourseId = courses.Single(c => c.Title == "Trigonometry" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Alonso").PersonId,
                    CourseId = courses.Single(c => c.Title == "Composition" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Anand").PersonId,
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Anand").PersonId,
                    CourseId = courses.Single(c => c.Title == "Microeconomics").CourseId,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Barzdukas").PersonId,
                    CourseId = courses.Single(c => c.Title == "Chemistry").CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Li").PersonId,
                    CourseId = courses.Single(c => c.Title == "Composition").CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Justice").PersonId,
                    CourseId = courses.Single(c => c.Title == "Literature").CourseId,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.PersonId == e.StudentId &&
                            s.Course.CourseId == e.CourseId).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}