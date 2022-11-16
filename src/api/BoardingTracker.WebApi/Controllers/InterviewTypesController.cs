using BoardingTracker.Application.InterviewTypes.Commands.CreateInterviewType;
using BoardingTracker.Application.InterviewTypes.Commands.DeleteInterviewType;
using BoardingTracker.Application.InterviewTypes.Commands.UpdateInterviewType;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Application.InterviewTypes.Queries.GetAllInterviewTypes;
using BoardingTracker.Application.InterviewTypes.Queries.GetInterviewTypesById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class InterviewTypesController : ApiController
    {
        public InterviewTypesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InterviewTypeList))]
        public async Task<IActionResult> CreateInterviewType([FromBody] CreateInterviewTypeRequest createInterviewTypeRequest)
        {
            var result = await Mediator.Send(createInterviewTypeRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterviewTypeList))]
        public async Task<IActionResult> DeleteInterviewType(int id)
        {
            var result = await Mediator.Send(new DeleteInterviewTypeRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterviewTypeList))]
        public async Task<IActionResult> UpdateInterviewType([FromBody] UpdateInterviewTypeRequest updateInterviewTypeRequest)
        {
            var result = await Mediator.Send(updateInterviewTypeRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterviewTypeList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetInterviewTypes());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterviewTypeList))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetInterviewTypeByIdRequest { Id = id });
            return Ok(result);
        }
    }
}
