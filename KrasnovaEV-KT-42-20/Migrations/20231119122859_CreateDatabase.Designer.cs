﻿// <auto-generated />
using System;
using KrasnovaEV_KT_42_20.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KrasnovaEV_KT_42_20.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20231119122859_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KrasnovaEV_KT_42_20.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasComment("Идентификатор записи зачета");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExamId"));

                    b.Property<DateTime?>("DateOfTest")
                        .IsRequired()
                        .HasColumnType("timestamp")
                        .HasColumnName("DateOfTest")
                        .HasComment("Дата проведения зачета");

                    b.Property<string>("ExamCondition")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("ExamCondition")
                        .HasComment("Состояние зачета (сдан/не сдан)");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("ExamName")
                        .HasComment("Название зачета");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("integer");

                    b.HasKey("ExamId")
                        .HasName("pk_Exam_Id");

                    b.HasIndex(new[] { "StudentId" }, "idx_Examfk_f_student_id");

                    b.HasIndex(new[] { "SubjectId" }, "idx_Examfk_f_subject_id");

                    b.ToTable("Exam", (string)null);
                });

            modelBuilder.Entity("KrasnovaEV_KT_42_20.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasComment("Идентификатор записи зачета");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GradeId"));

                    b.Property<DateTime?>("GradeDate")
                        .IsRequired()
                        .HasColumnType("timestamp")
                        .HasColumnName("GradeDate")
                        .HasComment("Дата получения оценки");

                    b.Property<int?>("GradeNumber")
                        .IsRequired()
                        .HasColumnType("int4")
                        .HasColumnName("GradeNumber")
                        .HasComment("Оценка");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("integer");

                    b.HasKey("GradeId")
                        .HasName("pk_Grade_Id");

                    b.HasIndex(new[] { "StudentId" }, "idx_Gradefk_f_student_id");

                    b.HasIndex(new[] { "SubjectId" }, "idx_Gradefk_f_subject_id");

                    b.ToTable("Grade", (string)null);
                });

            modelBuilder.Entity("KrasnovaEV_KT_42_20.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasComment("Идентификатор записи группы");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("GroupName")
                        .HasComment("Название группы");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bool")
                        .HasColumnName("IsDeleted")
                        .HasComment("Статус удаления");

                    b.Property<int?>("StudentQuantity")
                        .IsRequired()
                        .HasColumnType("int4")
                        .HasColumnName("StudentQuantity")
                        .HasComment("Количество студентов в группе");

                    b.HasKey("GroupId")
                        .HasName("pk_Groups_Id");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("KrasnovaEV_KT_42_20.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasComment("Идентификатор записи студента");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName")
                        .HasComment("Имя студента");

                    b.Property<int?>("GroupId")
                        .IsRequired()
                        .HasColumnType("int4")
                        .HasColumnName("GroupId")
                        .HasComment("Идентификатор группы");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bool")
                        .HasColumnName("IsDeleted")
                        .HasComment("Статус удаления");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName")
                        .HasComment("Фамилия студента");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("MiddleName")
                        .HasComment("Отчество студента");

                    b.HasKey("StudentId")
                        .HasName("pk_Students_Id");

                    b.HasIndex(new[] { "GroupId" }, "idx_Students_fk_f_group_id");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("KrasnovaEV_KT_42_20.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasComment("Идентификатор записи дисциплины");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubjectId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bool")
                        .HasColumnName("IsDeleted")
                        .HasComment("Статус удаления");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("SubjectName")
                        .HasComment("Название дисциплины");

                    b.HasKey("SubjectId")
                        .HasName("pk_Subject_Id");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("KrasnovaEV_KT_42_20.Models.Exam", b =>
                {
                    b.HasOne("KrasnovaEV_KT_42_20.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_f_student_id");

                    b.HasOne("KrasnovaEV_KT_42_20.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_f_subject_id");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("KrasnovaEV_KT_42_20.Models.Grade", b =>
                {
                    b.HasOne("KrasnovaEV_KT_42_20.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_f_student_id");

                    b.HasOne("KrasnovaEV_KT_42_20.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_f_subject_id");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("KrasnovaEV_KT_42_20.Models.Student", b =>
                {
                    b.HasOne("KrasnovaEV_KT_42_20.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_group_id");

                    b.Navigation("Group");
                });
#pragma warning restore 612, 618
        }
    }
}
