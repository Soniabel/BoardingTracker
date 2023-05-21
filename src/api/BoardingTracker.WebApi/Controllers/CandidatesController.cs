using BoardingTracker.Application.Candidates.Commands.CreateCandidate;
using BoardingTracker.Application.Candidates.Commands.DeleteCandidate;
using BoardingTracker.Application.Candidates.Commands.UpdateCandidate;
using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Application.Candidates.Queries.GetAllCandidates;
using BoardingTracker.Application.Candidates.Queries.GetCandidateById;
using BoardingTracker.Application.Candidates.Queries.GetCandidateSkill;
using BoardingTracker.Application.Skills.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class CandidatesController : ApiController
    {
        public CandidatesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CandidatesList))]
        public async Task<IActionResult> CreateCandidate([FromBody] CreateCandidateRequest createCandidateRequest)
        {
            var result = await Mediator.Send(createCandidateRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CandidatesList))]
        public async Task<IActionResult> DeleteCandidate(Guid id)
        {
            var result = await Mediator.Send(new DeleteCandidateRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CandidatesList))]
        public async Task<IActionResult> UpdateCandidate([FromBody] UpdateCandidateRequest updateCandidateRequest)
        {
            var result = await Mediator.Send(updateCandidateRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CandidatesList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetCandidates());
            return Ok(result);
        }

        [HttpGet("candidatebyuserid")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CandidatesList))]
        public async Task<IActionResult> GetById(string userId)
        {
            var result = await Mediator.Send(new GetCandidateByIdRequest { UserId = Guid.Parse(userId) });
            return Ok(result);
        }

        [HttpGet("skills/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SkillList))]
        public async Task<IActionResult> SkillListByCandidateId(string userId)
        {
            var result = await Mediator.Send(new GetSkillsByCandidateIdRequest { UserId = Guid.Parse(userId) });
            return Ok(result);
        }
    }
}
