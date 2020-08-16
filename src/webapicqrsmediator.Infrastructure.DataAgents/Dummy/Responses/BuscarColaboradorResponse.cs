using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace webapicqrsmediator.Infrastructure.DataAgents.Dummy.Responses
{
    public class BuscarColaboradorResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public IEnumerable<dynamic> Dados { get; set; }
    }
}