using Microsoft.EntityFrameworkCore;

namespace API_CadastroClientes.MODELS
{
    public class _DbContext:DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Usuarios> usuario { get; set; }
    }
}
