using BoardingTracker.Application.Interviews.Commands.CreateInterview;
using BoardingTracker.Application.Interviews.Commands.DeleteInterview;
using BoardingTracker.Application.Interviews.Commands.UpdateInterview;
using BoardingTracker.Application.Interviews.Models;
using BoardingTracker.Application.Interviews.Queries.GetAllInterviews;
using BoardingTracker.Application.Interviews.Queries.GetInterviewsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class InterviewsController : ApiController
    {
        public InterviewsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InterviewsList))]
        public async Task<IActionResult> CreateInterview([FromBody] CreateInterviewRequest createInterviewRequest)
        {
            var result = await Mediator.Send(createInterviewRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterviewsList))]
        public async Task<IActionResult> DeleteInterview(int id)
        {
            var result = await Mediator.Send(new DeleteInterviewRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterviewsList))]
        public async Task<IActionResult> UpdateInterview([FromBody] UpdateInterviewRequest updateInterviewRequest)
        {
            var result = await Mediator.Send(updateInterviewRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterviewsList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetInterviews());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InterviewsList))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetInterviewByIdRequest { Id = id });
            return Ok(result);
        }
    }
}
