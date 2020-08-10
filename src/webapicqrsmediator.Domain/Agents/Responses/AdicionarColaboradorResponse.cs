using System.Text.Json.Serialization;

namespace webapicqrsmediator.Infrastructure.Data.Agents.Responses
{
    public class AdicionarColaboradorResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public DadosColaboradorResponse Dados { get; set; }
    }
}