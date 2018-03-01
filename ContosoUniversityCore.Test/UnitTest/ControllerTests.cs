using ContosoUniversityCore.Data;
using ContosoUniversityCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using ContosoUniversityCore.Controllers;

namespace ContosoUniversityCore.Test.UnitTest
{
    public class ControllerTests
    {

        //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing
        [Fact]
        public async Task SampleControllerTest()
        {
            //Arrange
            SchoolContext schoolContext = GetSchoolContext();
            StudentsController studentController = new StudentsController(schoolContext);

            //Act
            Student newStudent = new Student()
            {
                FirstName = "Keith",
                LastName = "Joel",
                EnrollmentDate = DateTime.Now
            };

            await studentController.Create(newStudent);

            Student dbStudent = schoolContext.Students
                .Where(student => student.FirstName == newStudent.FirstName && student.LastName == newStudent.LastName).SingleOrDefault();

            Assert.NotNull(dbStudent);

        }

        private SchoolContext GetSchoolContext()
        {
            DbContextOptions<SchoolContext> contextOptions;

            var builder = new DbContextOptionsBuilder<SchoolContext>();

            builder.UseInMemoryDatabase("EFCoreDatabase");

            contextOptions = builder.Options;

            SchoolContext schoolContext = new SchoolContext(contextOptions);
            schoolContext.Database.EnsureDeleted();
            schoolContext.Database.EnsureCreated();

            return schoolContext;

        }
    }
}
