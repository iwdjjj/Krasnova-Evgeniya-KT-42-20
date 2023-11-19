using KrasnovaEV_KT_42_20.Database.Helpers;
using KrasnovaEV_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KrasnovaEV_KT_42_20.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "Subject";
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.SubjectId)
                .HasName($"pk_{TableName}_Id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.SubjectId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.SubjectId)
                .HasColumnName("Id")
                .HasComment("Идентификатор записи дисциплины");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.SubjectName)
                .IsRequired()
                .HasColumnName("SubjectName")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название дисциплины");

            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Статус удаления");

            builder.ToTable(TableName);
        }
    }
}
