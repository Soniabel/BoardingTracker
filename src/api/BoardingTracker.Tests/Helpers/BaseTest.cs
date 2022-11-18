using AutoMapper;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardingTracker.Tests.Helpers
{
    public class BaseTest : IDisposable
    {
        protected readonly DBBoardingTrackerContext _dbContext;

        protected readonly IMapper _mapper;

        public BaseTest()
        {
            _dbContext = InitTestDbContext();

            _mapper = AutoMapperHelper.Mapper;
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        public DBBoardingTrackerContext InitTestDbContext()
        {
            var options = new DbContextOptionsBuilder<DBBoardingTrackerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DBBoardingTrackerContext(options);
            context.Database.EnsureCreated();

            SeedDb(context);
            context.SaveChanges();

            return context;
        }

        private void SeedDb(DBBoardingTrackerContext context)
        {
            if (!context.SeniorityLevels.Any())
            {
                var seniorityLevel = new List<SeniorityLevel>()
                {
                    new SeniorityLevel { Name = "TestName" },
                    new SeniorityLevel { Name = "TestName" }
                };

                context.AddRange(seniorityLevel);
                context.SaveChanges();
            }

            if (!context.VacancyTypes.Any())
            {
                var vacancyType = new List<VacancyType>()
                {
                    new VacancyType { Name = "TestName" },
                    new VacancyType { Name = "TestName" }
                };

                context.AddRange(vacancyType);
                context.SaveChanges();
            }

            if (!context.VacancyStatuses.Any())
            {
                var vacancyStatus = new List<VacancyStatus>()
                {
                    new VacancyStatus { Name = "TestName" },
                    new VacancyStatus { Name = "TestName" }
                };

                context.AddRange(vacancyStatus);
                context.SaveChanges();
            }

            if (!context.Recruiters.Any())
            {
                var recruiter = new List<Recruiter>()
                {
                    new Recruiter
                    {
                        FirstName = "TestFirstName",
                        LastName = "TestLastName",
                        ProfileImageUrl = "TestImage",
                        UserId = 1
                    },
                    new Recruiter
                    {
                        FirstName = "TestFirstName",
                        LastName = "TestLastName",
                        ProfileImageUrl = "TestImage",
                        UserId = 1
                    }
                };

                context.AddRange(recruiter);
                context.SaveChanges();
            }

            if (!context.Skills.Any())
            {
                var skill = new List<Skill>()
                {
                    new Skill
                    {
                        Name = "TestName"
                    },
                    new Skill
                    {
                        Name = "TestName"
                    }
                };

                context.AddRange(skill);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var users = new List<User>()
                {
                    new User
                    {
                        Email = "TestEmail",
                        Password = "TestPassword",
                        Role = "TestRole"
                    },
                    new User
                    {
                        Email = "TestEmail",
                        Password = "TestPassword",
                        Role = "TestRole"
                    }
                };

                context.AddRange(users);
                context.SaveChanges();
            }

            if (!context.InterviewTypes.Any())
            {
                var interviewTypes = new List<InterviewType>()
                {
                    new InterviewType
                    {
                        Name = "TestName"
                    },
                    new InterviewType
                    {
                        Name = "TestName"
                    }
                };

                context.AddRange(interviewTypes);
                context.SaveChanges();
            }

            if (!context.Vacancies.Any())
            {
                var vacancies = new List<Vacancy>()
                {
                    new Vacancy
                    {
                        Title = "TestTitle",
                        Description = "TestDescription",
                        Salary = 1234,
                        SeniorityLevelId = 1,
                        VacancyTypeId = 1,
                        VacancyStatusId = 1,
                        RecruiterId = 1
                    },
                    new Vacancy
                    {
                        Title = "TestTitle",
                        Description = "TestDescription",
                        Salary = 1234,
                        SeniorityLevelId = 1,
                        VacancyTypeId = 1,
                        VacancyStatusId = 1,
                        RecruiterId = 1
                    }
                };

                context.AddRange(vacancies);
                context.SaveChanges();
            }

            if (!context.Candidates.Any())
            {
                var candidates = new List<Candidate>()
                {
                    new Candidate
                    {
                       FirstName = "TestName",
                       LastName = "TestName",
                       PhoneNumber = "TestPhone",
                       Biography = "TestBiography",
                       ResumeUrl = "TestResumeUrl",
                       UserId = 1
                    },
                    new Candidate
                    {
                       FirstName = "TestName",
                       LastName = "TestName",
                       PhoneNumber = "TestPhone",
                       Biography = "TestBiography",
                       ResumeUrl = "TestResumeUrl",
                       UserId = 1
                    }
                };

                context.AddRange(candidates);
                context.SaveChanges();
            }

            if (!context.Interviews.Any())
            {
                var interviews = new List<Interview>()
                {
                    new Interview
                    {
                        Title = "TestTitle",
                        StartTime = new DateTime(2022, 12, 12),
                        EndTime = new DateTime(2022, 12, 12),
                        VacancyId = 1,
                        RecruiterId = 1,
                        CandidateId = 1,
                        InterviewTypeId = 1
                    }
                };

                context.AddRange(interviews);
                context.SaveChanges();
            }

            if (!context.VacancySkills.Any())
            {
                var vacancySkills = new List<VacancySkill>()
                {
                    new VacancySkill
                    {
                        SkillId = 1,
                        VacancyId = 1
                    }
                };

                context.AddRange(vacancySkills);
                context.SaveChanges();
            }

            if (!context.CandidateSkills.Any())
            {
                var candidateSkills = new List<CandidateSkill>()
                {
                    new CandidateSkill
                    {
                        SkillId = 1,
                        CandidateId = 1
                    }
                };

                context.AddRange(candidateSkills);
                context.SaveChanges();
            }
        }
    }
}
