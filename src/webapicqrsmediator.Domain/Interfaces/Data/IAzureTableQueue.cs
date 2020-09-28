using System.Threading.Tasks;

namespace webapicqrsmediator.Domain.Interfaces.Data
{
    public interface IAzureTableQueue
    {
        Task<bool> ExisteFilaAsync(string nomeFila);

        Task CriarFilaAsync(string nomeFila);

        Task DeletarFilaAsync(string nomeFila);

        Task InserirMensagemAsync(string nomeFila, string mensagem);

        Task<string> RemoverMensagemAsync(string nomeFila);
    }
}