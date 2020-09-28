using System;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Entitites;
using webapicqrsmediator.Domain.Interfaces.Converters;

namespace webapicqrsmediator.Domain.Converters
{
    /// <summary>
    /// Conversor para preparar a entidade para adição no banco de dados em memória
    /// </summary>
    public class ClienteConverter : IConversor<AdicionarClienteDataRequest, Cliente>
    {
        public Cliente Convert(AdicionarClienteDataRequest input)
        {
            return new Cliente(
                nome: input.Nome, 
                email: input.Email, 
                data: DateTime.UtcNow
            );
        }
    }
}