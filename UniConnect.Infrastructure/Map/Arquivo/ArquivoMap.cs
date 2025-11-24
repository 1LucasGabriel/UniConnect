using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniConnect.Domain.Entity;

namespace UniConnect.Infrastructure.Mappings
{
    public class ArquivoMap : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.ToTable("arquivo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Tipo)
                .HasMaxLength(30);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.DataCriacao)
                .IsRequired();
            builder.Property(x => x.DataAlteracao);

            builder.Property(x => x.TamanhoBytes).IsRequired();

            builder.HasOne(x => x.PastaEstudo)
                .WithMany(x => x.Arquivos)
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
