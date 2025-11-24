using Microsoft.EntityFrameworkCore;
using UniConnect.Domain.Entity.Entity;
using UniConnect.Infrastructure.Map;

namespace UniConnect.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
    }
    public DbSet<Usuario> User { get; set; }
}