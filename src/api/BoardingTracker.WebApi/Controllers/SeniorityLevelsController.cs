using BoardingTracker.Application.SeniorityLevels.Commands.CreateSeniorityLevel;
using BoardingTracker.Application.SeniorityLevels.Commands.DeleteSeniorityLevel;
using BoardingTracker.Application.SeniorityLevels.Commands.UpdateSeniorityLevel;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Application.SeniorityLevels.Queries.GetAllSeniorityLevels;
using BoardingTracker.Application.SeniorityLevels.Queries.GetSeniorityLevelsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class SeniorityLevelsController : ApiController
    {
        public SeniorityLevelsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SeniorityLevelsList))]
        public async Task<IActionResult> CreateSeniorityLevel([FromBody] CreateSeniorityLevelRequest createSeniorityLevelRequest)
        {
            var result = await Mediator.Send(createSeniorityLevelRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeniorityLevelsList))]
        public async Task<IActionResult> DeleteSeniorityLevel(int id)
        {
            var result = await Mediator.Send(new DeleteSeniorityLevelRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeniorityLevelsList))]
        public async Task<IActionResult> UpdateSeniorityLevel([FromBody] UpdateSeniorityLevelRequest updateSeniorityLevelRequest)
        {
            var result = await Mediator.Send(updateSeniorityLevelRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeniorityLevelsList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetSeniorityLevels());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeniorityLevelsList))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetSeniorityLevelByIdRequest { Id = id });
            return Ok(result);
        }
    }
}
