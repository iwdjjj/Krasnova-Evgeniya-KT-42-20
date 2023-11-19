using KrasnovaEV_KT_42_20.Database.Configurations;
using KrasnovaEV_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace KrasnovaEV_KT_42_20.Database
{
    public class StudentDbContext : DbContext
    {
        //Добавляем таблицы
        DbSet<Exam> Exams { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
    }
}
