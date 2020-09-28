using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Entitites;
using webapicqrsmediator.Domain.Interfaces.Converters;

namespace webapicqrsmediator.Domain.Converters
{
    /// <summary>
    /// Conversor para responder à requisição após manipulação de adição no banco de dados em memória
    /// </summary>
    public class ClienteResponseConverter : IConversor<Cliente, AdicionarClienteDataResponse>
    {
        public AdicionarClienteDataResponse Convert(Cliente input)
        {
            return new AdicionarClienteDataResponse
            {
                Id = input.Id,
                Nome = input.Nome,
                Email = input.Email,
                DataCriacao = input.DataCriacao
            };
        }
    }
}