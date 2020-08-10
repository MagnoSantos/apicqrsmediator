using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;
using webapicqrsmediator.Domain.Commands.Response;

namespace webapicqrsmediator.Domain.Commands
{
    public class ClienteRequest : IRequest<ClienteResponse>
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// Validação dos parâmetros do corpo da requisição, no caso os dados do DTO: ClienteRequest
    /// Link de referência: https://fluentvalidation.net/
    /// </summary>
    public class AdicionarClienteValidator : AbstractValidator<ClienteRequest>
    {
        public AdicionarClienteValidator()
        {
            RuleFor(cliente => cliente.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("O campo de nome deve ser preenchido")
                .NotNull().WithMessage("O campo de nome não pode ser nulo")
                .MaximumLength(25).WithMessage("O campo deve conter no máximo 25 caracteres");

            RuleFor(cliente => cliente.Email)
                .EmailAddress();
        }
    }
}