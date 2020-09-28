using System;
using webapicqrsmediator.Domain.Entities;

namespace webapicqrsmediator.Domain.Entitites
{
    public class Cliente : Base
    {
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