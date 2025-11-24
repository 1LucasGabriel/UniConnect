
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniConnect.Domain.Entity;

namespace UniConnect.Infrastructure.Map;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Telefone).HasMaxLength(20);
        builder.Property(x => x.Senha).IsRequired();
        builder.Property(x => x.FotoPerfilUrl).HasMaxLength(300);

        builder.Property(x => x.TipoUsuario).IsRequired();

        builder.Property(x => x.DataCriacao)
                .IsRequired();
        builder.Property(x => x.DataAlteracao);

        //Relacionamentos gerais
        builder.HasMany(x => x.DiscussoesCriadas)
            .WithOne(x => x.UsuarioCriacao)
            .HasForeignKey(x => x.UsuarioCriacaoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.RespostasCriadas)
            .WithOne(x => x.UsuarioCriacao)
            .HasForeignKey(x => x.UsuarioCriacaoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.PastasCriadas)
            .WithOne(x => x.UsuarioCriacao)
            .HasForeignKey(x => x.UsuarioCriacaoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ArquivosCriados)
            .WithOne(x => x.UsuarioCriacao)
            .HasForeignKey(x => x.UsuarioCriacaoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.MensagensEnviadas)
            .WithOne(x => x.UsuarioCriacao)
            .HasForeignKey(x => x.UsuarioCriacaoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.MensagensRecebidas)
            .WithOne(x => x.UsuarioDestino)
            .HasForeignKey(x => x.UsuarioDestinoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(x => x.UsuarioCriacao);
        builder.Ignore(x => x.UsuarioAlteracao);
    }
}
