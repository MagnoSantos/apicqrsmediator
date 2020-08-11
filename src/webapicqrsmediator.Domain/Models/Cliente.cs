using System;

namespace webapicqrsmediator.Domain.Models
{
    public class Cliente : Base
    {
        public Cliente() { }

        public Cliente(string nome, string email, DateTime data)
        {
            Nome = nome;
            Email = email;
            DataCriacao = data;
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}