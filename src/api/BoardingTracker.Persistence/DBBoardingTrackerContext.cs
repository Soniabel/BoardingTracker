using System;
using System.Collections.Generic;
using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BoardingTracker.Persistence
{
    public partial class DBBoardingTrackerContext : DbContext
    {
        //public DBBoardingTrackerContext()
        //{
        //}

        public DBBoardingTrackerContext(DbContextOptions<DBBoardingTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; } = null!;

        public virtual DbSet<CandidateSkill> CandidateSkills { get; set; } = null!;

        public virtual DbSet<Interview> Interviews { get; set; } = null!;

        public virtual DbSet<InterviewType> InterviewTypes { get; set; } = null!;

        public virtual DbSet<Recruiter> Recruiters { get; set; } = null!;

        public virtual DbSet<SeniorityLevel> SeniorityLevels { get; set; } = null!;

        public virtual DbSet<Skill> Skills { get; set; } = null!;

        public virtual DbSet<User> Userss { get; set; } = null!;

        public virtual DbSet<Vacancy> Vacancies { get; set; } = null!;

        public virtual DbSet<VacancyCandidate> VacancyCandidates { get; set; } = null!;

        public virtual DbSet<VacancySkill> VacancySkills { get; set; } = null!;

        public virtual DbSet<VacancyStatus> VacancyStatuses { get; set; } = null!;

        public virtual DbSet<VacancyType> VacancyTypes { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        //    var entityTypes = modelBuilder.Model
        //    .GetEntityTypes()
        //    .ToList();

        //    var foreignKeys = entityTypes
        //        .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
        //    foreach (var foreignKey in foreignKeys)
        //    {
        //        foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        //    }
        //}

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<Candidate>(entity =>
        //        {
        //            entity.Property(e => e.FirstName).HasMaxLength(50);

        //            entity.Property(e => e.LastName).HasMaxLength(50);

        //            entity.Property(e => e.PhoneNumber).HasMaxLength(50);

        //            entity.HasOne(d => d.User)
        //                .WithMany(p => p.Candidates)
        //                .HasForeignKey(d => d.UserId)
        //                .HasConstraintName("FK__Candidate__UserI__398D8EEE");
        //        });

        //        modelBuilder.Entity<CandidateSkill>(entity =>
        //        {
        //            entity.HasNoKey();

        //            entity.HasOne(d => d.Candidate)
        //                .WithMany()
        //                .HasForeignKey(d => d.CandidateId)
        //                .HasConstraintName("FK__Candidate__Candi__3A81B327");

        //            entity.HasOne(d => d.Skill)
        //                .WithMany()
        //                .HasForeignKey(d => d.SkillId)
        //                .HasConstraintName("FK__Candidate__Skill__3B75D760");
        //        });

        //        modelBuilder.Entity<Interview>(entity =>
        //        {
        //            entity.Property(e => e.EndTime).HasColumnType("datetime");

        //            entity.Property(e => e.StartTime).HasColumnType("datetime");

        //            entity.Property(e => e.Title).HasMaxLength(50);

        //            entity.HasOne(d => d.Candidate)
        //                .WithMany(p => p.Interviews)
        //                .HasForeignKey(d => d.CandidateId)
        //                .HasConstraintName("FK__Interview__Candi__45F365D3");

        //            entity.HasOne(d => d.InterviewType)
        //                .WithMany(p => p.Interviews)
        //                .HasForeignKey(d => d.InterviewTypeId)
        //                .HasConstraintName("FK__Interview__Inter__46E78A0C");

        //            entity.HasOne(d => d.Recruiter)
        //                .WithMany(p => p.Interviews)
        //                .HasForeignKey(d => d.RecruiterId)
        //                .HasConstraintName("FK__Interview__Recru__44FF419A");

        //            entity.HasOne(d => d.Vacancy)
        //                .WithMany(p => p.Interviews)
        //                .HasForeignKey(d => d.VacancyId)
        //                .HasConstraintName("FK__Interview__Vacan__440B1D61");
        //        });

        //        modelBuilder.Entity<InterviewType>(entity =>
        //        {
        //            entity.Property(e => e.Name).HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Recruiter>(entity =>
        //        {
        //            entity.Property(e => e.FirstName).HasMaxLength(50);

        //            entity.Property(e => e.LastName).HasMaxLength(50);

        //            entity.HasOne(d => d.User)
        //                .WithMany(p => p.Recruiters)
        //                .HasForeignKey(d => d.UserId)
        //                .HasConstraintName("FK__Recruiter__UserI__38996AB5");
        //        });

        //        modelBuilder.Entity<SeniorityLevel>(entity =>
        //        {
        //            entity.Property(e => e.Name).HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<Skill>(entity =>
        //        {
        //            entity.Property(e => e.Name).HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<User>(entity =>
        //        {
        //            entity.Property(e => e.Email).HasMaxLength(50);

        //            entity.Property(e => e.Password).HasMaxLength(100);

        //            entity.Property(e => e.Role).HasMaxLength(20);
        //        });

        //        modelBuilder.Entity<Vacancy>(entity =>
        //        {
        //            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

        //            entity.Property(e => e.Title).HasMaxLength(50);

        //            entity.HasOne(d => d.Recruiter)
        //                .WithMany(p => p.Vacancies)
        //                .HasForeignKey(d => d.RecruiterId)
        //                .HasConstraintName("FK__Vacancies__Recru__4316F928");

        //            entity.HasOne(d => d.SeniorityLevel)
        //                .WithMany(p => p.Vacancies)
        //                .HasForeignKey(d => d.SeniorityLevelId)
        //                .HasConstraintName("FK__Vacancies__Senio__403A8C7D");

        //            entity.HasOne(d => d.VacancyStatus)
        //                .WithMany(p => p.Vacancies)
        //                .HasForeignKey(d => d.VacancyStatusId)
        //                .HasConstraintName("FK__Vacancies__Vacan__4222D4EF");

        //            entity.HasOne(d => d.VacancyType)
        //                .WithMany(p => p.Vacancies)
        //                .HasForeignKey(d => d.VacancyTypeId)
        //                .HasConstraintName("FK__Vacancies__Vacan__412EB0B6");
        //        });

        //        modelBuilder.Entity<VacancyCandidate>(entity =>
        //        {
        //            entity.HasNoKey();

        //            entity.HasOne(d => d.Candidate)
        //                .WithMany()
        //                .HasForeignKey(d => d.CandidateId)
        //                .HasConstraintName("FK__VacancyCa__Candi__3F466844");

        //            entity.HasOne(d => d.Vacancy)
        //                .WithMany()
        //                .HasForeignKey(d => d.VacancyId)
        //                .HasConstraintName("FK__VacancyCa__Vacan__3E52440B");
        //        });

        //        modelBuilder.Entity<VacancySkill>(entity =>
        //        {
        //            entity.HasNoKey();

        //            entity.HasOne(d => d.Skill)
        //                .WithMany()
        //                .HasForeignKey(d => d.SkillId)
        //                .HasConstraintName("FK__VacancySk__Skill__3D5E1FD2");

        //            entity.HasOne(d => d.Vacancy)
        //                .WithMany()
        //                .HasForeignKey(d => d.VacancyId)
        //                .HasConstraintName("FK__VacancySk__Vacan__3C69FB99");
        //        });

        //        modelBuilder.Entity<VacancyStatus>(entity =>
        //        {
        //            entity.Property(e => e.Name).HasMaxLength(50);
        //        });

        //        modelBuilder.Entity<VacancyType>(entity =>
        //        {
        //            entity.Property(e => e.Name).HasMaxLength(50);
        //        });

        //        OnModelCreatingPartial(modelBuilder);
        //    }

        //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
