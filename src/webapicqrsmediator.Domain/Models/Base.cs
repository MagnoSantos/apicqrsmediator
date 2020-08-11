using System;

namespace webapicqrsmediator.Domain.Models
{
    public class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}