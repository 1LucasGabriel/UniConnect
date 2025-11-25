using Microsoft.EntityFrameworkCore;
using UniConnect.Argument.Enums;
using UniConnect.Domain.Entity;

namespace UniConnect.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<Usuario>().HasData(
            new Usuario("Admin", "admin", "0000000", "UPHOAqVE0er6hexBH82HaEWie+OWSko2VBy2lzqVUHg=", "", TipoUsuario.Administrador).SetDefaultValueForMigraiton()
        );
    }

    public DbSet<Usuario> Usuario { get; private set; }
    public DbSet<PastaEstudo> PastaEstudo { get; private set; }
    public DbSet<Arquivo> Arquivo { get; private set; }
    public DbSet<Discussao> Discussao { get; private set; }
    public DbSet<Resposta> Resposta { get; private set; }
    public DbSet<DiscussaoReacao> DiscussaoReacao { get; private set; }
    public DbSet<RespostaReacao> RespostaReacao { get; private set; }
    public DbSet<Mensagem> Mensagem { get; private set; }
}