using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Queries;

namespace webapicqrsmediator.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Adicionar(
            [FromServices] IMediator mediator,
            [FromBody] AdicionarClienteRequest command
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var clienteAdicionado = await mediator.Send(command);

            return CreatedAtAction(
                nameof(ObterPorId),
                new { id = clienteAdicionado.Id },
                clienteAdicionado
            );
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterPorId(
            [FromServices] IMediator mediator,
            [FromQuery] ObterClientePorIdRequest command
        )
        {
            var clienteObtido = await mediator.Send(command);

            if (clienteObtido == null)
                return NotFound();

            return Ok(clienteObtido);
        }
    }
}