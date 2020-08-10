
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using webapicqrsmediator.Domain;

namespace webapicqrsmediator.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Adicionar(
            [FromServices] IMediator mediator,
            [FromBody] ColaboradorRequest command
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var colaboradorAdicionado = await mediator.Send(command);

            return Created(new Uri(Request.GetEncodedUrl()), colaboradorAdicionado);
        }
    }
}