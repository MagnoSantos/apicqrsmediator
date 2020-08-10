using System;

namespace webapicqrsmediator.Domain.Commands.Response
{
    public class ClienteResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}