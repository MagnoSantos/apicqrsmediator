using MediatR;
using System;
using webapicqrsmediator.Domain.Queries.Response;

namespace webapicqrsmediator.Domain.Queries
{
    public class ObterClientePorIdRequest : IRequest<ObterClientePorIdResponse>, ICaching
    {
        public Guid Id { get; set; }

        public string Chave => $"{GetType().Name}:{Id}";
    }
}