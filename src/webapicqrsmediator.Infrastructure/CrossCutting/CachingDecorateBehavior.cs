using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Queries.Cache;

namespace webapicqrsmediator.Infrastructure.CrossCutting
{
    public class CachingDecorateBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IMemoryCache _cache;

        public CachingDecorateBehavior(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is ICaching requisicaoCacheada)
            {
                var chave = requisicaoCacheada.Chave;

                if (_cache.TryGetValue(chave, out TResponse respostaCacheada))
                {
                    return respostaCacheada;
                }

                var resposta = await next();

                return _cache.Set(
                    chave,
                    resposta,
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                    }
                );
            }

            return await next();
        }
    }
}