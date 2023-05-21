using BoardingTracker.Application.Recruiters.Commands.CreateRecruiter;
using BoardingTracker.Application.Recruiters.Commands.DeleteRecruiter;
using BoardingTracker.Application.Recruiters.Commands.UpdateRecruiter;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.Recruiters.Queries.GetAllRecruiters;
using BoardingTracker.Application.Recruiters.Queries.GetRecruitersById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class RecruitersController : ApiController
    {
        public RecruitersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RecruitersList))]
        public async Task<IActionResult> CreateRecruiter([FromBody] CreateRecruiterRequest createRecruiterRequest)
        {
            var result = await Mediator.Send(createRecruiterRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecruitersList))]
        public async Task<IActionResult> DeleteRecruiter(Guid id)
        {
            var result = await Mediator.Send(new DeleteRecruiterRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecruitersList))]
        public async Task<IActionResult> UpdateRecruiter([FromBody] UpdateRecruiterRequest updateRecruiterRequest)
        {
            var result = await Mediator.Send(updateRecruiterRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecruitersList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetRecruiters());
            return Ok(result);
        }

        [HttpGet("recruiterbyuserid")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecruitersList))]
        public async Task<IActionResult> GetById(string userId)
        {
            var result = await Mediator.Send(new GetRecruiterByIdRequest {  UserId = Guid.Parse(userId) });
            return Ok(result);
        }
    }
}
