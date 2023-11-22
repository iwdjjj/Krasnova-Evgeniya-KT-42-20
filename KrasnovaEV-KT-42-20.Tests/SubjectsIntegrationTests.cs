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
    public class SubjectsIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public SubjectsIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>().UseInMemoryDatabase(databaseName: "Student").Options;
        }

        [Fact]
        public async Task GetSubjectsByDescriptionAsync_Design_TwoObject()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var subjectService = new SubjectService(ctx);
            var subjects = new List<Subject>
            {
                new Subject
                {
                    SubjectName = "A",
                    SubjectDescription = "Design",
                    IsDeleted = false
                },
                new Subject
                {
                    SubjectName = "B",
                    SubjectDescription = "Design",
                    IsDeleted = false
                },
                new Subject
                {
                    SubjectName = "C",
                    SubjectDescription = "Programming",
                    IsDeleted = false
                }
            };
            await ctx.Set<Subject>().AddRangeAsync(subjects);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.SubjectFilters.SubjectDescriptionFilter
            {
                SubjectDescription = "Design"
            };
            var subjectsResult = await subjectService.GetSubjectsByDescriptionAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, subjectsResult.Length);
        }
    }
}
