using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Features.Third.Commands.CreateThirdParty;
using SoftLine.Trebol.Application.Features.Third.Commands.DeleteThirdParty;
using SoftLine.Trebol.Application.Features.Third.Commands.UpdateThirdParty;
using SoftLine.Trebol.Application.Features.Third.Queries.Vms;

namespace SoftLine.Trebol.WebAPIRest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdPartyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ThirdPartyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create", Name = "CreateThirdPartyReceipt")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ThirdPartyVm>> CreateThirdParty([FromBody] CreateThirdPartyCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteThirdPartyCommand { Id = id });
            return NoContent();
        }
    }
}
