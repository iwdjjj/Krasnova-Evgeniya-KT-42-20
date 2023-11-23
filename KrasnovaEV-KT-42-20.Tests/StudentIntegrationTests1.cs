using KrasnovaEV_KT_42_20.Database;
using KrasnovaEV_KT_42_20.Interfaces;
using KrasnovaEV_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrasnovaEV_KT_42_20.Tests
{
    public class StudentIntegrationTests1
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests1()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>().UseInMemoryDatabase(databaseName: "Student").Options;
        }

        [Fact]
        public async Task GetStudentsByFIOAsync_qwerty_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-42-20",
                    GroupJob = "",
                    GroupYear = "",
                    StudentQuantity = 20
                },
                new Group
                {
                    GroupName = "KT-31-20",
                    GroupJob = "",
                    GroupYear = "",
                    StudentQuantity = 20
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    Surname = "qwerty",
                    Name = "Ivan",
                    Midname = "zxc",
                    GroupId = 1,
                    IsDeleted = false
                },
                new Student
                {
                    Surname = "qwerty",
                    Name = "asdf",
                    Midname = "zxc",
                    GroupId = 2,
                    IsDeleted = false
                },
                new Student
                {
                    Surname = "qwerty3",
                    Name = "Ivan",
                    Midname = "zxc3",
                    GroupId = 1,
                    IsDeleted = false
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.StudentFilters.StudentFIOFilter
            {
                Surname = "",
                Name = "Ivan",
                Midname = "",
            };
            var studentsResult = await studentService.GetStudentsByFIOAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }
    }
}
