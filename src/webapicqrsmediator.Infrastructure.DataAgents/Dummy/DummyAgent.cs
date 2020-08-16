using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polly;
using System.Threading.Tasks;
using webapicqrsmediator.Infrastructure.Data.Agents.Dummy.Options;
using webapicqrsmediator.Infrastructure.Data.Agents.Dummy.Responses;
using webapicqrsmediator.Infrastructure.DataAgents.Dummy.Responses;

namespace webapicqrsmediator.Infrastructure.DataAgents
{
    public class DummyAgent : IDummyAgent
    {
        private readonly DummyOptions _options;

        public DummyAgent(IOptionsMonitor<DummyOptions> options)
        {
            _options = options.CurrentValue;
        }

        /// <summary>
        /// Resiliência de APIs (polly retry) | Request com Flurl
        /// Links de referência: https://github.com/App-vNext/Polly | https://flurl.dev/
        /// </summary>
        /// <param name="colaborador"></param>
        /// <returns></returns>
        public async Task<AdicionarColaboradorResponse> AdicionarColaborador(string nome, string salario, string idade)
        {
            return await Policy
                .Handle<FlurlHttpException>()
                .RetryAsync()
                .ExecuteAsync(() =>
                   _options.UrlBase
                    .AppendPathSegments("api", "v1", "create")
                    .PostJsonAsync(new
                    {
                        name = $"{nome}",
                        salario = $"{salario}",
                        idade = $"{idade}"
                    })
                    .ReceiveJson<AdicionarColaboradorResponse>()
            );
        }

        public async Task<BuscarColaboradorResponse> BuscarTodosColaboradores()
        {
            return await Policy
                .Handle<FlurlHttpException>()
                .RetryAsync()
                .ExecuteAsync(() =>
                    _options.UrlBase
                    .AppendPathSegment("employees")
                    .GetAsync()
                    .ReceiveJson<BuscarColaboradorResponse>()
                );
        }
    }
}