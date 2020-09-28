using System;

namespace webapicqrsmediator.Infrastructure.Data.EntityFrameworkCore.Entities
{
    public class ClienteEntity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}