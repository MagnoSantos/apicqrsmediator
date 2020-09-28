using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Queries;
using webapicqrsmediator.Infrastructure.CrossCutting.Caching.Options;

namespace webapicqrsmediator.Infrastructure.CrossCutting
{
    public class CachingDecorateBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly CacheOptions _options;
        private readonly IMemoryCache _cache;

        public CachingDecorateBehavior(IOptionsMonitor<CacheOptions> options,
                                       IMemoryCache cache)
        {
            _options = options.CurrentValue;
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
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(_options.TempoRetencaoCacheEmDias)
                    }
                );
            }

            return await next();
        }
    }
}