using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Queries;
using webapicqrsmediator.Domain.Queries.Response;
using webapicqrsmediator.Shared;

namespace webapicqrsmediator.Api.Controllers
{
    [ApiController]
    [Route(Constantes.Rotas.RoutePrefix)]
    public class ClienteController : ControllerBase
    {
        /// <summary>
        /// Requisição para adicionar um novo cliente.
        /// </summary>
        /// <param name="mediator">Diminui o acoplamento e aumenta o reuso das dependências na aplicação</param>
        /// <param name="command">Corpo da requisição do cliente </param>
        /// <returns>Retorno corresponde ao cliente que foi adicionado após processada a requisição</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Adicionar(
            [FromServices] IMediator mediator,
            [FromBody] AdicionarClienteDataRequest command
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

        /// <summary>
        /// Requisição para obter um cliente por Id 
        /// </summary>
        /// <param name="mediator">Diminiu o acoplamento e aumenta o reuso das dependências na aplicação</param>
        /// <param name="command">Query Param contendo o Id do cliente a ser obtido</param>
        /// <returns>Retorno corresponde ao cliente que foi obtido após processada a requisição</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Sucesso<ObterClientePorIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Falha), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterPorId(
            [FromServices] IMediator mediator,
            [FromQuery] ObterClientePorIdRequest command
        )
        {
            var clienteObtido = await mediator.Send(command);

            if (clienteObtido == null)
                return NotFound(new Falha(Constantes.Erros.ClienteNaoEncontrado));

            return Ok(
                new Sucesso<ObterClientePorIdResponse>(
                  new ObterClientePorIdResponse
                  {
                      Id = clienteObtido.Id,
                      Nome = clienteObtido.Nome,
                      Email = clienteObtido.Email, 
                  }
                )
            );
        }
    }
}