﻿// <auto-generated />
using System;
using BoardingTracker.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardingTracker.Persistence.Migrations
{
    [DbContext(typeof(DBBoardingTrackerContext))]
    partial class DBBoardingTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ResumeUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.CandidateSkill", b =>
                {
                    b.Property<Guid?>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("CandidateId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CandidateSkills");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("InterviewTypeId")
                        .HasColumnType("int");

                    b.Property<Guid?>("RecruiterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("InterviewTypeId");

                    b.HasIndex("RecruiterId");

                    b.HasIndex("VacancyId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.InterviewType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("InterviewTypes");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Recruiter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("RefreshTokenGID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserGID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RefreshTokenGID");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.SeniorityLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SeniorityLevels");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Userss");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RecruiterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int?>("SeniorityLevelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("VacancyStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("VacancyTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecruiterId");

                    b.HasIndex("SeniorityLevelId");

                    b.HasIndex("VacancyStatusId");

                    b.HasIndex("VacancyTypeId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.VacancyCandidate", b =>
                {
                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.Property<Guid?>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VacancyId", "CandidateId");

                    b.HasIndex("CandidateId");

                    b.ToTable("VacancyCandidates");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.VacancySkill", b =>
                {
                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.HasKey("SkillId", "VacancyId");

                    b.HasIndex("VacancyId");

                    b.ToTable("VacancySkills");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.VacancyStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("VacancyStatuses");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.VacancyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("VacancyTypes");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Candidate", b =>
                {
                    b.HasOne("BoardingTracker.Domain.Entities.User", "User")
                        .WithMany("Candidates")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Candidates_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.CandidateSkill", b =>
                {
                    b.HasOne("BoardingTracker.Domain.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CandidateSkill_CandidateId");

                    b.HasOne("BoardingTracker.Domain.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CandidateSkill_SkillId");

                    b.Navigation("Candidate");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Interview", b =>
                {
                    b.HasOne("BoardingTracker.Domain.Entities.Candidate", "Candidate")
                        .WithMany("Interviews")
                        .HasForeignKey("CandidateId")
                        .HasConstraintName("FK_Interviews_CandidateId");

                    b.HasOne("BoardingTracker.Domain.Entities.InterviewType", "InterviewType")
                        .WithMany("Interviews")
                        .HasForeignKey("InterviewTypeId")
                        .HasConstraintName("FK_Interviews_InterviewTypeId");

                    b.HasOne("BoardingTracker.Domain.Entities.Recruiter", "Recruiter")
                        .WithMany("Interviews")
                        .HasForeignKey("RecruiterId")
                        .HasConstraintName("FK_Interviews_RecruiterId");

                    b.HasOne("BoardingTracker.Domain.Entities.Vacancy", "Vacancy")
                        .WithMany("Interviews")
                        .HasForeignKey("VacancyId")
                        .HasConstraintName("FK_Interviews_VacancyId");

                    b.Navigation("Candidate");

                    b.Navigation("InterviewType");

                    b.Navigation("Recruiter");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Recruiter", b =>
                {
                    b.HasOne("BoardingTracker.Domain.Entities.User", "User")
                        .WithMany("Recruiters")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Recruiters_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("BoardingTracker.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Vacancy", b =>
                {
                    b.HasOne("BoardingTracker.Domain.Entities.Recruiter", "Recruiter")
                        .WithMany("Vacancies")
                        .HasForeignKey("RecruiterId")
                        .HasConstraintName("FK_Vacancies_RecruiterId");

                    b.HasOne("BoardingTracker.Domain.Entities.SeniorityLevel", "SeniorityLevel")
                        .WithMany("Vacancies")
                        .HasForeignKey("SeniorityLevelId")
                        .HasConstraintName("FK_Vacancies_SeniorityLevelId");

                    b.HasOne("BoardingTracker.Domain.Entities.VacancyStatus", "VacancyStatus")
                        .WithMany("Vacancies")
                        .HasForeignKey("VacancyStatusId")
                        .HasConstraintName("FK_Vacancies_VacancyStatusId");

                    b.HasOne("BoardingTracker.Domain.Entities.VacancyType", "VacancyType")
                        .WithMany("Vacancies")
                        .HasForeignKey("VacancyTypeId")
                        .HasConstraintName("FK_Vacancies_VacancyTypeId");

                    b.Navigation("Recruiter");

                    b.Navigation("SeniorityLevel");

                    b.Navigation("VacancyStatus");

                    b.Navigation("VacancyType");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.VacancyCandidate", b =>
                {
                    b.HasOne("BoardingTracker.Domain.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VacancyCandidate_CandidateId");

                    b.HasOne("BoardingTracker.Domain.Entities.Vacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VacancyCandidate_VacancyId");

                    b.Navigation("Candidate");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.VacancySkill", b =>
                {
                    b.HasOne("BoardingTracker.Domain.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VacancySkill_SkillId");

                    b.HasOne("BoardingTracker.Domain.Entities.Vacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VacancySkill_VacancyId");

                    b.Navigation("Skill");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Candidate", b =>
                {
                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.InterviewType", b =>
                {
                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Recruiter", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.SeniorityLevel", b =>
                {
                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.User", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("Recruiters");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.Vacancy", b =>
                {
                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.VacancyStatus", b =>
                {
                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("BoardingTracker.Domain.Entities.VacancyType", b =>
                {
                    b.Navigation("Vacancies");
                });
#pragma warning restore 612, 618
        }
    }
}
