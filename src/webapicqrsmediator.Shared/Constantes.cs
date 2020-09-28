using System;

namespace webapicqrsmediator.Shared
{
    public static class Constantes
    {
        public static class Erros
        {
            public const string InternalServerError = "Erro interno da aplicação";
            public const string ClienteNaoEncontrado = "Não foi encontrado cliente com o Id informado";
        }

        public static class Rotas
        {
            public const string RoutePrefix = "api/v{version:apiVersion}/[controller]";
        }
    }
}
