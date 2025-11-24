using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniConnect.Domain.Entity;

namespace UniConnect.Infrastructure.Mappings
{
    public class RespostaReacaoMap : IEntityTypeConfiguration<RespostaReacao>
    {
        public void Configure(EntityTypeBuilder<RespostaReacao> builder)
        {
            builder.ToTable("resposta_reacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo).IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired();
            builder.Property(x => x.DataAlteracao);

            builder.HasOne(x => x.Resposta)
                .WithMany(x => x.Reacoes)
                .HasForeignKey(x => x.RespostaId)
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
