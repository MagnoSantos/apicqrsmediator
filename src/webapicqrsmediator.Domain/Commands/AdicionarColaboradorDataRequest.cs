using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;
using webapicqrsmediator.Domain.Commands.Response;

namespace webapicqrsmediator.Domain
{
    public class AdicionarColaboradorDataRequest : IRequest<AdicionarColaboradorDataResponse>
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("name")]
        public string Salario { get; set; }

        [JsonPropertyName("name")]
        public string Idade { get; set; }
    }

    /// <summary>
    /// Validação dos parâmetros do corpo da requisição, no caso os dados do DTO: ColaboradorRequest
    /// Link de referência: https://fluentvalidation.net/
    /// </summary>
    public class ColaboradorValidator : AbstractValidator<AdicionarColaboradorDataRequest>
    {
        public ColaboradorValidator()
        {
            RuleFor(colaborador => colaborador.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("O campo de nome deve ser preenchido")
                .NotNull().WithMessage("O campo de nome não pode ser nulo");

            RuleFor(colaborador => colaborador.Salario)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("O campo de salario deve ser preenchido")
                .NotNull().WithMessage("O campo de salario não pode ser nulo");

            RuleFor(colaborador => colaborador.Idade)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("O campo de idade deve ser preenchido")
                .NotNull().WithMessage("O campo de idade não pode ser nulo");
        }
    }
}