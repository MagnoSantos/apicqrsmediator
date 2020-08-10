using System.Threading.Tasks;
using webapicqrsmediator.Domain.Entities;
using webapicqrsmediator.Infrastructure.Data.Agents.Responses;

namespace webapicqrsmediator.Domain.Agents
{
    public interface IColaboradorAgent
    {
        Task<AdicionarColaboradorResponse> AdicionarColaborador(Colaborador colaborador);
    }
}