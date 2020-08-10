using Microsoft.EntityFrameworkCore;
using webapicqrsmediator.Domain.Entities;

namespace webapicqrsmediator.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}