using System.Threading.Tasks;
using webapicqrsmediator.Infrastructure.DataAgents.Responses;

namespace webapicqrsmediator.Infrastructure.DataAgents
{
    public interface IColaboradorAgent
    {
        Task<AdicionarColaboradorResponse> AdicionarColaborador(string nome, string salario, string idade);
    }
}