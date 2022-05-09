using AtividadeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AtividadeAPI.Data
{
    public class AtividadeDBContext : DbContext
    {
        public AtividadeDBContext(DbContextOptions<AtividadeDBContext> options) : base(options)
        {
        }

        public DbSet<Atividade> Atividade { get; set; }
    }
}
