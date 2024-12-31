using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Edification.Models;

namespace Edification.Data
{
    public partial class EdificationContext : DbContext
    {
        public EdificationContext()
        {
        }

        public EdificationContext(DbContextOptions<EdificationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CoursesToFacuility> CoursesToFacuilities { get; set; } = null!;
        public virtual DbSet<Facuility> Facuilities { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<QuestionQuiz> QuestionQuizzes { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<StudentEnrollCourse> StudentEnrollCourses { get; set; } = null!;
        public virtual DbSet<UsersRegistration> UsersRegistrations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  =>
                optionsBuilder.UseSqlServer();
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CoursesId)
                    .HasName("PK__courses__57C470BBF360A608");

                entity.ToTable("courses");

                entity.Property(e => e.CoursesId).HasColumnName("courses_id");

                entity.Property(e => e.CourseAction)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("course_action");

                entity.Property(e => e.CoursesFees).HasColumnName("courses_fees");

                entity.Property(e => e.CoursesName)
                    .HasMaxLength(66)
                    .IsUnicode(false)
                    .HasColumnName("courses_name");

                entity.Property(e => e.CoursesRequiredPercentage)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("courses_required_percentage");
            });

            modelBuilder.Entity<CoursesToFacuility>(entity =>
            {
                entity.HasKey(e => e.CoursesFacuilityId)
                    .HasName("PK__Courses___339B4D76A0F6AF37");

                entity.ToTable("Courses_To_Facuility");

                entity.Property(e => e.CoursesFacuilityId).HasColumnName("Courses_Facuility_id");

                entity.Property(e => e.CoursesId).HasColumnName("courses_id");

                entity.Property(e => e.FacuilityId).HasColumnName("Facuility_id");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.CoursesToFacuilities)
                    .HasForeignKey(d => d.CoursesId)
                    .HasConstraintName("FK__Courses_T__cours__5812160E");

                entity.HasOne(d => d.Facuility)
                    .WithMany(p => p.CoursesToFacuilities)
                    .HasForeignKey(d => d.FacuilityId)
                    .HasConstraintName("FK__Courses_T__Facui__59063A47");
            });

            modelBuilder.Entity<Facuility>(entity =>
            {
                entity.ToTable("Facuility");

                entity.Property(e => e.FacuilityId).HasColumnName("Facuility_id");

                entity.Property(e => e.FacuilityEmail)
                    .HasMaxLength(77)
                    .IsUnicode(false)
                    .HasColumnName("Facuility_email");

                entity.Property(e => e.FacuilityName)
                    .HasMaxLength(77)
                    .IsUnicode(false)
                    .HasColumnName("Facuility_name");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.Property(e => e.LectureId).HasColumnName("Lecture_id");

                entity.Property(e => e.LectureLink)
                    .IsUnicode(false)
                    .HasColumnName("Lecture_link");

                entity.Property(e => e.LectureName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Lecture_name");

                entity.Property(e => e.QuizNature).HasColumnName("Quiz_Nature");
            });

            modelBuilder.Entity<QuestionQuiz>(entity =>
            {
                entity.ToTable("Question_Quiz");

                entity.Property(e => e.QuestionQuizId).HasColumnName("Question_Quiz_id");

                entity.Property(e => e.OptionOne)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Option_One");

                entity.Property(e => e.OptionThree)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Option_Three");

                entity.Property(e => e.OptionTwo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Option_Two");

                entity.Property(e => e.Question)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionsTotalNum).HasColumnName("Questions_total_num");

                entity.Property(e => e.QuizId).HasColumnName("Quiz_id");

                entity.Property(e => e.RightAnswer)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Right_Answer");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuestionQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__Question___Quiz___59FA5E80");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.QuizId).HasColumnName("Quiz_id");

                entity.Property(e => e.QuizName)
                    .HasMaxLength(66)
                    .IsUnicode(false)
                    .HasColumnName("Quiz_name");

                entity.Property(e => e.QuizNature)
                    .HasMaxLength(66)
                    .IsUnicode(false)
                    .HasColumnName("Quiz_nature");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.QuizId).HasColumnName("Quiz_id");

                entity.Property(e => e.ResultsGrade)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Results_Grade");

                entity.Property(e => e.ResultsObtainNum).HasColumnName("Results_Obtain_num");

                entity.Property(e => e.ResultsPercentage).HasColumnName("Results_percentage");

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.HasOne(d => d.Quiz)
                    .WithMany()
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__Results__Quiz_id__5BE2A6F2");

                entity.HasOne(d => d.Users)
                    .WithMany()
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Results__users_i__5AEE82B9");
            });

            modelBuilder.Entity<StudentEnrollCourse>(entity =>
            {
                entity.HasKey(e => e.StdCourseid)
                    .HasName("PK__StudentE__707407BF8B322F74");

                entity.ToTable("StudentEnrollCourse");

                entity.Property(e => e.StdCourseid).HasColumnName("std_courseid");

                entity.Property(e => e.CourseEmail)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("course_email");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.CoursePassword)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("course_password");

                entity.Property(e => e.CoursesId).HasColumnName("courses_id");

                entity.Property(e => e.CoursesJoining)
                    .HasColumnType("date")
                    .HasColumnName("courses_joining");

                entity.Property(e => e.FacilityId).HasColumnName("facility_id");

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.HasOne(d => d.Courses)
                    .WithMany(p => p.StudentEnrollCourses)
                    .HasForeignKey(d => d.CoursesId)
                    .HasConstraintName("FK__StudentEn__cours__5DCAEF64");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.StudentEnrollCourses)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__StudentEn__users__5CD6CB2B");
            });

            modelBuilder.Entity<UsersRegistration>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__users_re__EAA7D14B1B7F975F");

                entity.ToTable("users_registration");

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.Property(e => e.UsersEmail)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("users_email");

                entity.Property(e => e.UsersName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("users_name");

                entity.Property(e => e.UsersPassword)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("users_password");

                entity.Property(e => e.UsersRole)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("users_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
