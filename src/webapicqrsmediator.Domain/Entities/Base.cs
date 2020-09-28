using System;

namespace webapicqrsmediator.Domain.Entities
{
    public class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}