using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniConnect.Domain.Entity;

namespace UniConnect.Infrastructure.Mappings
{
    public class PastaEstudoMap : IEntityTypeConfiguration<PastaEstudo>
    {
        public void Configure(EntityTypeBuilder<PastaEstudo> builder)
        {
            builder.ToTable("pasta_estudo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.Property(x => x.Visibilidade).IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired();
            builder.Property(x => x.DataAlteracao);

            builder.HasOne(x => x.PastaPai)
                .WithMany(x => x.SubPastas)
                .HasForeignKey(x => x.PastaEstudoPaiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Arquivos)
                .WithOne(x => x.PastaEstudo)
                .HasForeignKey(x => x.PastaEstudoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.UsuarioCriacao)
               .WithMany()
               .HasForeignKey(x => x.UsuarioCriacaoId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UsuarioAlteracao)
                .WithMany()
                .HasForeignKey(x => x.UsuarioAlteracaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
