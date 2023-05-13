using AutoMapper;
using BoardingTracker.Application.Candidates.Commands.CreateCandidate;
using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Application.Interviews.Commands.CreateInterview;
using BoardingTracker.Application.Interviews.Models;
using BoardingTracker.Application.InterviewTypes.Commands.CreateInterviewType;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Application.Recruiters.Commands.CreateRecruiter;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.SeniorityLevels.Commands.CreateSeniorityLevel;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Application.Skills.Commands.CreateSkill;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Application.Users.Commands.CreateUser;
using BoardingTracker.Application.Users.Models;
using BoardingTracker.Application.Vacancies.Commands.CreateVacancy;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Application.VacancyStatuses.Commands.CreateVacancyStatus;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Application.VacancyTypes.Commands.CreateVacancyType;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Domain.Entities;

namespace BoardingTracker.Application.Infrastructure.Mapper
{
    public class BoardingTrackerMappingProfile : Profile
    {
        public BoardingTrackerMappingProfile()
        {
            CreateMap<CandidateModel, Candidate>().ReverseMap();
            CreateMap<CreateCandidateRequest, Candidate>().ReverseMap();

            CreateMap<SkillModel, Skill>().ReverseMap();
            CreateMap<CreateSkillRequest, Skill>().ReverseMap();

            CreateMap<Vacancy, VacancyModel>().ReverseMap();
            CreateMap<CreateVacancyRequest, Vacancy>().ReverseMap();

            CreateMap<VacancyStatusModel, VacancyStatus>().ReverseMap();
            CreateMap<CreateVacancyStatusRequest, VacancyStatus>().ReverseMap();

            CreateMap<VacancyTypeModel, VacancyType>().ReverseMap();
            CreateMap<CreateVacancyTypeRequest, VacancyType>().ReverseMap();

            CreateMap<SeniorityLevelModel, SeniorityLevel>().ReverseMap();
            CreateMap<CreateSeniorityLevelRequest, SeniorityLevel>().ReverseMap();

            CreateMap<RecruiterModel, Recruiter>().ReverseMap();
            CreateMap<CreateRecruiterRequest, Recruiter>().ReverseMap();

            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<CreateUserRequest, User>().ReverseMap();

            CreateMap<Interview, InterviewModel>().ReverseMap();
            CreateMap<CreateInterviewRequest, Interview>().ReverseMap();

            CreateMap<CreateInterviewTypeRequest, InterviewType>().ReverseMap();
            CreateMap<InterviewTypeModel, InterviewType>().ReverseMap();
        }
    }
}
