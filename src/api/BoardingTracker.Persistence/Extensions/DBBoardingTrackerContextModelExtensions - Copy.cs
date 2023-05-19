using BoardingTracker.Domain.Entities;

namespace BoardingTracker.Persistence.Extensions
{
    public static class DBBoardingTrackerContextModelExtensions
    {
        public static async Task SeedDatabase(this DBBoardingTrackerContext context)
        {
            try
            {
                await TrySeedDatabase(context);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task TrySeedDatabase(this DBBoardingTrackerContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        Email = "FirstUser@gmail.com",
                        Password = "FirstPassword",
                        Role = "Candidate"
                    },
                    new User()
                    {
                        Email = "SecondUser@gmail.com",
                        Password = "Secondpassword",
                        Role = "Recruiter"
                    },
                    new User()
                    {
                        Email = "ThirdUser@gmail.com",
                        Password = "ThirdPassword",
                        Role = "Candidate"
                    },
                    new User()
                    {
                        Email = "FourthUser@gmail.com",
                        Password = "FourthPassword",
                        Role = "Recruiter"
                    }
                };
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }

            if (!context.Candidates.Any())
            {
                var candidates = new List<Candidate>()
                {
                    new Candidate()
                    {
                        FirstName = "FirstCandidateName",
                        LastName = "FirstCandidateLastName",
                        PhoneNumber = "11111111111",
                        Biography = "FirstCandidateBiography",
                        ResumeUrl = "FirstCandidateResumeUrl",
                        //UserId = 1
                    },
                    new Candidate()
                    {
                        FirstName = "SecondCandidateName",
                        LastName = "SecondCandidateLastName",
                        PhoneNumber = "333333333333",
                        Biography = "SecondCandidateBiography",
                        ResumeUrl = "SecondCandidateResumeUrl",
                        //UserId = 3
                    }
                };
                await context.Candidates.AddRangeAsync(candidates);
                await context.SaveChangesAsync();
            }

            if (!context.Recruiters.Any())
            {
                var recruiters = new List<Recruiter>()
                {
                    new Recruiter()
                    {
                        FirstName = "FirstRecruiterName",
                        LastName = "FirstRecruiterLastName",
                        ProfileImageUrl = "FirstRecruiterImageUrl",
                        //UserId = 2
                    },
                    new Recruiter()
                    {
                        FirstName = "SecondRecruiterName",
                        LastName = "SecondRecruiterLastName",
                        ProfileImageUrl = "SecondRecruiterImageUrl",
                        //UserId = 4
                    }
                };
                await context.Recruiters.AddRangeAsync(recruiters);
                await context.SaveChangesAsync();
            }

            if (!context.Skills.Any())
            {
                var skils = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "MSSQL"
                    },
                    new Skill()
                    {
                        Name = "C++"
                    }
                };
                await context.Skills.AddRangeAsync(skils);
                await context.SaveChangesAsync();
            }

            if (!context.CandidateSkills.Any())
            {
                var candidateSkills = new List<CandidateSkill>()
                {
                    new CandidateSkill()
                    {
                        //CandidateId = 1,
                        SkillId = 1
                    },
                    new CandidateSkill()
                    {
                        //CandidateId = 1,
                        SkillId = 2
                    }
                };
                await context.CandidateSkills.AddRangeAsync(candidateSkills);
                await context.SaveChangesAsync();
            }

            if (!context.SeniorityLevels.Any())
            {
                var seniorityLevels = new List<SeniorityLevel>()
                {
                    new SeniorityLevel()
                    {
                        Name = "Junior"
                    },
                    new SeniorityLevel()
                    {
                        Name = "Middle"
                    }
                };
                await context.SeniorityLevels.AddRangeAsync(seniorityLevels);
                await context.SaveChangesAsync();
            }

            if (!context.VacancyTypes.Any())
            {
                var vacancyTypes = new List<VacancyType>()
                {
                    new VacancyType()
                    {
                        Name = "Full Time"
                    },
                    new VacancyType()
                    {
                        Name = "Part Time"
                    }
                };
                await context.VacancyTypes.AddRangeAsync(vacancyTypes);
                await context.SaveChangesAsync();
            }

            if (!context.VacancyStatuses.Any())
            {
                var vacancyStatuses = new List<VacancyStatus>()
                {
                    new VacancyStatus()
                    {
                        Name = "Open"
                    },
                    new VacancyStatus()
                    {
                        Name = "Closed"
                    }
                };
                await context.VacancyStatuses.AddRangeAsync(vacancyStatuses);
                await context.SaveChangesAsync();
            }

            if (!context.Vacancies.Any())
            {
                var vacancies = new List<Vacancy>()
                {
                    new Vacancy()
                    {
                        Title = "FirstVacancy",
                        Description = "FirstDescription",
                        Salary = 1000,
                        SeniorityLevelId = 1,
                        VacancyTypeId = 1,
                        VacancyStatusId = 1,
                        //RecruiterId = 1
                    },
                    new Vacancy()
                    {
                        Title = "SecondVacancy",
                        Description = "SecondDescription",
                        Salary = 2000,
                        SeniorityLevelId = 2,
                        VacancyTypeId = 2,
                        VacancyStatusId = 2,
                        //RecruiterId = 2
                    }
                };
                await context.Vacancies.AddRangeAsync(vacancies);
                await context.SaveChangesAsync();
            }

            if (!context.VacancySkills.Any())
            {
                var vacansySkills = new List<VacancySkill>()
                {
                    new VacancySkill()
                    {
                        VacancyId = 1,
                        SkillId = 1
                    },
                    new VacancySkill()
                    {
                        VacancyId = 2,
                        SkillId = 2
                    }
                };
                await context.VacancySkills.AddRangeAsync(vacansySkills);
                await context.SaveChangesAsync();
            }

            if (!context.VacancyCandidates.Any())
            {
                var vacancyCandidates = new List<VacancyCandidate>()
                {
                    new VacancyCandidate()
                    {
                        VacancyId = 1,
                        //CandidateId = 1
                    },
                    new VacancyCandidate()
                    {
                        VacancyId = 2,
                        //CandidateId = 2
                    }
                };
                await context.VacancyCandidates.AddRangeAsync(vacancyCandidates);
                await context.SaveChangesAsync();
            }

            if (!context.InterviewTypes.Any())
            {
                var interviewTypes = new List<InterviewType>()
                {
                    new InterviewType()
                    {
                        Name = "FirstInterviewType"
                    },
                    new InterviewType()
                    {
                        Name = "SecondInterviewType"
                    }
                };
                await context.InterviewTypes.AddRangeAsync(interviewTypes);
                await context.SaveChangesAsync();
            }

            if (!context.Interviews.Any())
            {
                var interviews = new List<Interview>()
                {
                    new Interview()
                    {
                        Title = "FirstTitleInterview",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        VacancyId = 1,
                        //RecruiterId = 1,
                        //CandidateId = 1,
                        InterviewTypeId = 1
                    },
                    new Interview()
                    {
                        Title = "SecondTitleInterview",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        VacancyId = 2,
                        //RecruiterId = 2,
                        //CandidateId = 2,
                        InterviewTypeId = 2
                    }
                };
                await context.Interviews.AddRangeAsync(interviews);
                await context.SaveChangesAsync();
            }
        }
    }
}
