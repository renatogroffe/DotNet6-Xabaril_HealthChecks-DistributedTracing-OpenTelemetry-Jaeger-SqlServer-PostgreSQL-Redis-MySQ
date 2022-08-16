using Microsoft.EntityFrameworkCore;

namespace APIContagem.Data;

public class ContagemContext : DbContext
{
    public DbSet<HistoricoContagem>? Historicos { get; set; }

    public ContagemContext(DbContextOptions<ContagemContext> options) :
        base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoricoContagem>(entity =>
        {
            entity.ToTable("HistoricoContagem");
            entity.HasKey(c => c.Id);
        });
    }
}