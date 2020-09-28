using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace webapicqrsmediator.Shared
{
    public static class ExtensionsMethods
    {
        public static async Task<string> ObterConteudo(this Stream body)
        {
            using var corpo = new StreamReader(body, Encoding.UTF8, true, 1024, true);
            return await corpo.ReadToEndAsync();
        }
    }
}