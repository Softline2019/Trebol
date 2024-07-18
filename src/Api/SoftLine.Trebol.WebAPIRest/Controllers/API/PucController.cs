using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Features.Pucs.Commands.UpdatePuc;
using SoftLine.Trebol.Application.Features.Pucs.Commands.DeletePuc;
using SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using System.Threading.Tasks;
using SoftLine.Trebol.Application.Features.Pucs.Queries.GetPucs;

namespace SoftLine.Trebol.WebAPIRest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PucsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PucsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreatePucsCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            PucsVm result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePucCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePucCommand(id));
            return NoContent();
        }

        [HttpGet("getAll", Name = "GetPucs")]
        [ProducesResponseType(typeof(List<PucsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<PucsVm>>> GetPucs()
        {
            var query = new GetPucsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}", Name = "GetPucById")]
        [ProducesResponseType(typeof(PucsVm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<PucsVm>> GetPucById(int id)
        {
            var query = new GetPucsQueryById(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
