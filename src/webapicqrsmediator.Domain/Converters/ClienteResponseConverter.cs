using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Entitites;
using webapicqrsmediator.Domain.Interfaces.Converters;
using webapicqrsmediator.Domain.Queries.Response;

namespace webapicqrsmediator.Domain.Converters
{
    /// <summary>
    /// Conversor para responder à requisição após manipulação de adição no banco de dados em memória
    /// </summary>
    public class ClienteAdicionarResponseConverter :
        IConversor<AdicionarClienteDataRequest, AdicionarClienteDataResponse>
    {
        public AdicionarClienteDataResponse Convert(AdicionarClienteDataRequest input)
        {
            return new AdicionarClienteDataResponse
            {
                Nome = input.Nome,
                Email = input.Email
            };
        }
    }

    public class ClienteObterPorIdResponseConverter : IConversor<Cliente, ObterClientePorIdResponse>
    {
        public ObterClientePorIdResponse Convert(Cliente input)
        {
            return new ObterClientePorIdResponse
            {
                Id = input.Id,
                Email = input.Email,
                Nome = input.Nome
            };
        }
    }
}