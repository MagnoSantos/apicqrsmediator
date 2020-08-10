using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polly;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Agents;
using webapicqrsmediator.Domain.Entities;
using webapicqrsmediator.Infrastructure.Data.Agents.Options;
using webapicqrsmediator.Infrastructure.Data.Agents.Responses;

namespace webapicqrsmediator.Infrastructure.Data.Agents
{
    public class ColaboradorAgent : IColaboradorAgent
    {
        private readonly DummyOptions _options;

        public ColaboradorAgent(IOptionsMonitor<DummyOptions> options)
        {
            _options = options.CurrentValue;
        }

        /// <summary>
        /// Resiliência de APIs (polly retry) | Request com Flurl
        /// Links de referência: https://github.com/App-vNext/Polly | https://flurl.dev/
        /// </summary>
        /// <param name="colaborador"></param>
        /// <returns></returns>
        public async Task<AdicionarColaboradorResponse> AdicionarColaborador(Colaborador colaborador)
        {
            return await Policy
                .Handle<FlurlHttpException>()
                .RetryAsync()
                .ExecuteAsync(() =>
                   _options.UrlBase
                    .AppendPathSegments("api", "v1", "create")
                    .PostJsonAsync(colaborador)
                    .ReceiveJson<AdicionarColaboradorResponse>()
            );
        }
    }
}