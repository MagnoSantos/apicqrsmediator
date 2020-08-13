using System.Text.Json.Serialization;

namespace webapicqrsmediator.Infrastructure.Data.Agents.Dummy.Responses
{
    public class DadosColaboradorResponse
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("salario")]
        public string Salario { get; set; }

        [JsonPropertyName("idade")]
        public string Idade { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}