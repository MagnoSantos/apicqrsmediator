namespace webapicqrsmediator.Api.Controllers
{
    public class Sucesso<TData>
    {
        public TData Dados { get; }

        public Sucesso(TData dados)
        {
            Dados = dados;
        }
    }

    public class Falha
    {
        public Erro Erros { get; set; }

        public Falha(string mensagem)
        {
            Erros = new Erro 
            { 
                Mensagem = mensagem 
            };
        }
    }

    public class Erro
    {
        public string Mensagem { get; set; }
    }
}