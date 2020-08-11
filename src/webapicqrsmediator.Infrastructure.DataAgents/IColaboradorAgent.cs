using System.Threading.Tasks;
using webapicqrsmediator.Infrastructure.Data.Agents.Responses;

namespace webapicqrsmediator.Infrastructure.DataAgents
{
    public interface IColaboradorAgent
    {
        Task<AdicionarColaboradorResponse> AdicionarColaborador(string nome, string salario, string idade);
    }
}