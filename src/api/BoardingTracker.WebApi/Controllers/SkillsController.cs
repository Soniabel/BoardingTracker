using BoardingTracker.Application.Skills.Commands.CreateSkill;
using BoardingTracker.Application.Skills.Commands.DeleteSkill;
using BoardingTracker.Application.Skills.Commands.UpdateSkill;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Application.Skills.Queries.GetAllSkills;
using BoardingTracker.Application.Skills.Queries.GetSkillById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class SkillsController : ApiController
    {
        public SkillsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SkillList))]
        public async Task<IActionResult> CreateSkill([FromBody] CreateSkillRequest createSkillRequest)
        {
            var result = await Mediator.Send(createSkillRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkillList))]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await Mediator.Send(new DeleteSkillRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkillList))]
        public async Task<IActionResult> UpdateSkill([FromBody] UpdateSkillRequest updateSkillRequest)
        {
            var result = await Mediator.Send(updateSkillRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkillList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetSkills());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkillList))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetSkillByIdRequest { Id = id });
            return Ok(result);
        }
    }
}
