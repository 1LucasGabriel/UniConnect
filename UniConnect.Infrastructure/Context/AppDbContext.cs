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
            new Usuario
            {
                Nome = "Admin",
                Email = "admin",
                Senha = "UPHOAqVE0er6hexBH82HaEWie+OWSko2VBy2lzqVUHg=",
                Telefone = "0000000",
                FotoPerfilUrl = "",
                TipoUsuario = TipoUsuario.Administrador,
            }.SetDefaultValueForMigraiton()
        );
    }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<PastaEstudo> PastaEstudo { get; set; }
    public DbSet<Arquivo> Arquivo { get; set; }
    public DbSet<Discussao> Discussao { get; set; }
    public DbSet<Resposta> Resposta { get; set; }
    public DbSet<DiscussaoReacao> DiscussaoReacao { get; set; }
    public DbSet<RespostaReacao> RespostaReacao { get; set; }
    public DbSet<Mensagem> Mensagem  { get; set; }
}