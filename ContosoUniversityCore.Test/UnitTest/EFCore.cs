using ContosoUniversityCore.Data;
using ContosoUniversityCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;

namespace ContosoUniversityCore.Test.UnitTest
{
    public class EFCore
    {

        [Fact]
        public void AddPerson()
        {
            using (var context = GetSchoolContext())
            {
                var students = new List<Student>
                {
                    new Student { FirstName = "Carson",   LastName = "Alexander", EnrollmentDate = DateTime.Parse("2010-09-01") },
                    new Student { FirstName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstName = "Arturo",   LastName = "Anand", EnrollmentDate = DateTime.Parse("2013-09-01") },
                    new Student { FirstName = "Gytis",    LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstName = "Yan",      LastName = "Li", EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstName = "Peggy",    LastName = "Justice", EnrollmentDate = DateTime.Parse("2011-09-01") },
                    new Student { FirstName = "Laura",    LastName = "Norman",  EnrollmentDate = DateTime.Parse("2013-09-01") },
                    new Student { FirstName = "Nino",     LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
                };

                context.AddRange(students);
                context.SaveChanges();

                var numberOfStudents = context.Students.Count();
                Assert.Equal(9, numberOfStudents);
            }

        }

        private SchoolContext GetSchoolContext()
        {
            DbContextOptions<SchoolContext> contextOptions;

            var builder = new DbContextOptionsBuilder<SchoolContext>();

            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
            builder.UseInMemoryDatabase("EFCoreDatabase");

            contextOptions = builder.Options;

            SchoolContext schoolContext = new SchoolContext(contextOptions);
            schoolContext.Database.EnsureDeleted();
            schoolContext.Database.EnsureCreated();

            return schoolContext;

        }
    }
}
