using Microsoft.EntityFrameworkCore;

namespace WebApiMeta.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
           : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
