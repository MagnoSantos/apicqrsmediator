using webapicqrsmediator.Domain.Entities;

namespace webapicqrsmediator.Domain.Entitites
{
    public class Colaborador : Base
    {
        public Colaborador(string nome, string salario, string idade)
        {
            Nome = nome;
            Salario = salario;
            Idade = idade;
        }

        public string Nome { get; set; }

        public string Salario { get; set; }

        public string Idade { get; set; }
    }
}