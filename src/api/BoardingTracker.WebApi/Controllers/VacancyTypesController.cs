using BoardingTracker.Application.VacancyTypes.Commands.CreateVacancyType;
using BoardingTracker.Application.VacancyTypes.Commands.DeleteVacancyType;
using BoardingTracker.Application.VacancyTypes.Commands.UpdateVacancyType;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Application.VacancyTypes.Queries.GetAllVacancyTypes;
using BoardingTracker.Application.VacancyTypes.Queries.GetVacancyTypesById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class VacancyTypesController : ApiController
    {
        public VacancyTypesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VacancyTypeList))]
        public async Task<IActionResult> CreateVacancyType([FromBody] CreateVacancyTypeRequest createVacancyTypeRequest)
        {
            var result = await Mediator.Send(createVacancyTypeRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacancyTypeList))]
        public async Task<IActionResult> DeleteVacancyType(int id)
        {
            var result = await Mediator.Send(new DeleteVacancyTypeRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacancyTypeList))]
        public async Task<IActionResult> UpdateVacancyType([FromBody] UpdateVacancyTypeRequest updateVacancyTypeRequest)
        {
            var result = await Mediator.Send(updateVacancyTypeRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacancyTypeList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetVacancyTypes());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VacancyTypeList))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetVacancyTypeByIdRequest { Id = id });
            return Ok(result);
        }
    }
}
