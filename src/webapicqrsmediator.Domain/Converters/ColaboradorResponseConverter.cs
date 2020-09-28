using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Interfaces.Converters;
using webapicqrsmediator.Infrastructure.DataAgents.Responses;

namespace webapicqrsmediator.Domain.Converters
{
    /// <summary>
    /// Converter para retorno da resposta do DummyAgent para adição de um novo colaborador
    /// </summary>
    public class ColaboradorResponseConverter : IConversor<AdicionarColaboradorResponse, AdicionarColaboradorDataResponse>
    {
        public AdicionarColaboradorDataResponse Convert(AdicionarColaboradorResponse input)
        {
            return new AdicionarColaboradorDataResponse
            {
                Id = input.Dados?.Id,
                Nome = input.Dados?.Nome,
                Status = input.Status
            };
        }
    }
}