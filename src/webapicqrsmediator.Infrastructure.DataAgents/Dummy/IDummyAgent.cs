using System.Threading.Tasks;
using webapicqrsmediator.Infrastructure.Data.Agents.Dummy.Responses;
using webapicqrsmediator.Infrastructure.DataAgents.Dummy.Responses;

namespace webapicqrsmediator.Infrastructure.DataAgents
{
    public interface IDummyAgent
    {
        Task<AdicionarColaboradorResponse> AdicionarColaborador(string nome, string salario, string idade);

        Task<BuscarColaboradorResponse> BuscarTodosColaboradores();
    }
}