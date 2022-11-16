using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ApiController : ControllerBase
    {
        public ApiController(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }
    }

}
