using Microsoft.AspNetCore.Http;
using System.IO;

namespace webapicqrsmediator.Shared
{
    public static class ExtensionsMethods
    {
        public static string ObterConteudo(this Stream body)
        {
            using var corpo = new StreamReader(body);
            return corpo.ReadToEnd();
        }
    }
}