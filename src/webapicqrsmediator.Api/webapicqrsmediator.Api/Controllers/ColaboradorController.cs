using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using webapicqrsmediator.Domain;
using webapicqrsmediator.Shared;

namespace webapicqrsmediator.Api.Controllers
{
    [ApiController]
    [Route(Constantes.Rotas.RoutePrefix)]
    public class ColaboradorController : ControllerBase
    {
        /// <summary>
        /// Rota para adicionar um novo colocaborador através da integração com a API pública Dummy
        /// </summary>
        /// <param name="mediator">Diminui o acoplamento e aumenta o reuso das dependências na aplicação</param>
        /// <param name="command">Corpo da requisição do colaborador</param>
        /// <returns>Dados do colaborador após o processamento da requisição</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Adicionar(
            [FromServices] IMediator mediator,
            [FromBody] AdicionarColaboradorDataRequest command
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var colaboradorAdicionado = await mediator.Send(command);

            return Created(
                new Uri(Request.GetEncodedUrl()),
                colaboradorAdicionado
             );
        }
    }
}