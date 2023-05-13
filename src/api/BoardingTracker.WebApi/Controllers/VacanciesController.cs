using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Application.Vacancies.Commands.CreateVacancy;
using BoardingTracker.Application.Vacancies.Commands.DeleteVacancy;
using BoardingTracker.Application.Vacancies.Commands.UpdateVacancy;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Application.Vacancies.Queries.GetAllVacancies;
using BoardingTracker.Application.Vacancies.Queries.GetVacanciesById;
using BoardingTracker.Application.Vacancies.Queries.GetVacancySkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class VacanciesController : ApiController
    {
        public VacanciesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VacanciesList))]
        public async Task<IActionResult> CreateVacancy([FromBody] CreateVacancyRequest createVacancyRequest)
        {
            var result = await Mediator.Send(createVacancyRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacanciesList))]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            var result = await Mediator.Send(new DeleteVacancyRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacanciesList))]
        public async Task<IActionResult> UpdateVacancy([FromBody] UpdateVacancyRequest updateVacancyRequest)
        {
            var result = await Mediator.Send(updateVacancyRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacanciesList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetVacancies());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacancyModel))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetVacancyByIdRequest { Id = id });
            return Ok(result);
        }

        [HttpGet("skills/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkillList))]
        public async Task<IActionResult> SkillListByVacancyId(int id)
        {
            var result = await Mediator.Send(new GetSkillsByVacancyIdRequest { Id = id });
            return Ok(result);
        }
    }
}
