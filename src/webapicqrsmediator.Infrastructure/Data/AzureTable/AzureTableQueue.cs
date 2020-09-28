using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.Linq;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Interfaces.Data;

namespace webapicqrsmediator.Infrastructure.Data.AzureTable
{
    public class AzureTableQueue : IAzureTableQueue
    {
        private readonly CloudQueueClient _queueCliente;

        public AzureTableQueue(CloudStorageAccount storageAccount)
        {
            _queueCliente = storageAccount.CreateCloudQueueClient();
        }

        public Task CriarFilaAsync(string nomeFila)
        {
            return _queueCliente
                .GetQueueReference(nomeFila)
                .CreateIfNotExistsAsync();
        }

        public Task DeletarFilaAsync(string nomeFila)
        {
            return _queueCliente
                .GetQueueReference(nomeFila)
                .CreateIfNotExistsAsync();
        }

        public Task<bool> ExisteFilaAsync(string nomeFila)
        {
            return _queueCliente
                .GetQueueReference(nomeFila)
                .DeleteIfExistsAsync();
        }

        public Task InserirMensagemAsync(string nomeFila, string mensagem)
        {
            return _queueCliente
                .GetQueueReference(nomeFila)
                .AddMessageAsync(
                    message: new CloudQueueMessage(mensagem),
                    timeToLive: TimeSpan.FromSeconds(-1), // Infinite
                    initialVisibilityDelay: default,
                    options: null,
                    operationContext: null
                );
        }

        public async Task<string> RemoverMensagemAsync(string nomeFila)
        {
            var mensagens = await _queueCliente
                .GetQueueReference(nomeFila)
                .GetMessagesAsync(1);

            return mensagens.FirstOrDefault()?.AsString;
        }
    }
}