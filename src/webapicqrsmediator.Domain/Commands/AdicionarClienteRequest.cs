using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;
using webapicqrsmediator.Domain.Commands.Response;

namespace webapicqrsmediator.Domain.Commands
{
    public class AdicionarClienteRequest : IRequest<AdicionarClienteResponse>
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class AdicionarClienteValidator : AbstractValidator<AdicionarClienteRequest>
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