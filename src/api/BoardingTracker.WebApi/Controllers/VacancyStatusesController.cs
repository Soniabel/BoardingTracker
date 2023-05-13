using BoardingTracker.Application.VacancyStatuses.Commands.CreateVacancyStatus;
using BoardingTracker.Application.VacancyStatuses.Commands.DeleteVacancyStatus;
using BoardingTracker.Application.VacancyStatuses.Commands.UpdateVacancyStatus;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Application.VacancyStatuses.Queries.GetAllVacancyStatuses;
using BoardingTracker.Application.VacancyStatuses.Queries.GetVacancyStatusesById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class VacancyStatusesController : ApiController
    {
        public VacancyStatusesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VacancyStatusList))]
        public async Task<IActionResult> CreateVacancyStatus([FromBody] CreateVacancyStatusRequest createVacancyStatusRequest)
        {
            var result = await Mediator.Send(createVacancyStatusRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacancyStatusList))]
        public async Task<IActionResult> DeleteVacancyStatus(int id)
        {
            var result = await Mediator.Send(new DeleteVacancyStatusRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacancyStatusList))]
        public async Task<IActionResult> UpdateVacancyStatus([FromBody] UpdateVacancyStatusRequest updateVacancyStatusRequest)
        {
            var result = await Mediator.Send(updateVacancyStatusRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacancyStatusList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetVacancyStatuses());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacancyStatusList))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetVacancyStatusByIdRequest { Id = id });
            return Ok(result);
        }
    }

}
