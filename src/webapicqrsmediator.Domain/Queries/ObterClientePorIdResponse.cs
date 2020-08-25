using System;

namespace webapicqrsmediator.Domain.Queries.Response
{
    public class ObterClientePorIdResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
    }
}